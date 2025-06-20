import pandas as pd

# Load the dataset
file_path = 'C:/Users/rohan/FYP_AI/audio_steganography_results.csv'  # Adjust the file name as needed
data = pd.read_csv(file_path)

# Calculate quartiles for SNR and MSE
snr_quartiles = data['SNR (dB)'].quantile([0.25, 0.5, 0.75])
mse_quartiles = data['MSE'].quantile([0.25, 0.5, 0.75])

# Output quartile results
print("SNR Quartiles:")
print(snr_quartiles)
print("\nMSE Quartiles:")
print(mse_quartiles)

# Define ranges based on quartiles
def categorize_snr(snr):
    if snr < snr_quartiles[0.25]:
        return 'bad'
    elif snr < snr_quartiles[0.75]:
        return 'acceptable'
    else:
        return 'good'

def categorize_mse(mse):
    if mse < mse_quartiles[0.25]:
        return 'good'
    elif mse < mse_quartiles[0.75]:
        return 'acceptable'
    else:
        return 'bad'

# Apply the categorization
data['SNR Quality'] = data['SNR (dB)'].apply(categorize_snr)
data['MSE Quality'] = data['MSE'].apply(categorize_mse)

# Resolve conflicts to create a single quality column
def resolve_quality(snr_quality, mse_quality):
    if 'bad' in [snr_quality, mse_quality]:
        return 'bad'
    elif 'good' in [snr_quality, mse_quality] and 'acceptable' in [snr_quality, mse_quality]:
        return 'acceptable'
    elif snr_quality == 'good' and mse_quality == 'good':
        return 'good'
    else:
        return 'acceptable'

# Create the single quality column
data['Overall Quality'] = data.apply(lambda row: resolve_quality(row['SNR Quality'], row['MSE Quality']), axis=1)

# Drop the individual quality columns
data = data.drop(columns=['SNR Quality', 'MSE Quality'])

# Save or print the results
output_file = 'C:/Users/rohan/FYP_AI/audio_steganography_final_analysis.csv'
data.to_csv(output_file, index=False)
print(f"\nAnalysis completed. Results saved to {output_file}.")
