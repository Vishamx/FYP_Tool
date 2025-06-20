import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import os

def calculate_percentiles(df, columns):
    percentiles = {}
    for column in columns:
        percentiles[column] = {
            '25th': np.percentile(df[column], 25),
            '50th': np.percentile(df[column], 50),
            '75th': np.percentile(df[column], 75)
        }
    return percentiles

def plot_percentiles_separately(percentiles):
    for metric, values in percentiles.items():
        plt.figure()
        plt.bar(['25th', '50th', '75th'], [values['25th'], values['50th'], values['75th']], color=['blue', 'green', 'red'])
        plt.xlabel('Percentiles')
        plt.ylabel(f'{metric.upper()} Value')
        plt.title(f'Percentiles for {metric.upper()}')
        plt.show()

def update_quality(df, percentiles):
    conditions = {
        'good': lambda row: all([
            row['psnr'] >= percentiles['psnr']['75th'],
            row['mse'] <= percentiles['mse']['25th'],
            row['ssim'] >= percentiles['ssim']['75th']
        ]),
        'acceptable': lambda row: all([
            row['psnr'] >= percentiles['psnr']['50th'],
            row['mse'] <= percentiles['mse']['50th'],
            row['ssim'] >= percentiles['ssim']['50th']
        ]),
        'bad': lambda row: True
    }

    def assign_quality(row):
        for quality, condition in conditions.items():
            if condition(row):
                return quality
        return 'unknown'

    df['image_quality'] = df.apply(assign_quality, axis=1)
    return df

def main():
    
    input_file = 'C:/Users/rohan/FYP_AI/dataset.csv'
    output_file = 'C:/Users/rohan/FYP_AI/modified_dataset.csv'

    # Check if the output file already exists
    if os.path.exists(output_file):
        print(f"{output_file} already exists. Exiting script to avoid overwriting.")
        return

    # load the dataste
    df = pd.read_csv(input_file)

    
    percentiles = calculate_percentiles(df, ['psnr', 'mse', 'ssim'])
    
    
    print("Percentiles:")
    for metric, values in percentiles.items():
        print(f"{metric.upper()}:")
        for perc, value in values.items():
            print(f"  {perc}: {value}")

    # Plot percentiles separately
    plot_percentiles_separately(percentiles)

    # Update the quality column
    df_modified = update_quality(df, percentiles)

    # Save the modified dataset to a new CSV file
    df_modified.to_csv(output_file, index=False)
    print(f"Modified dataset saved to {output_file}")

if __name__ == "__main__":
    main()
