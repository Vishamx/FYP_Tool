import joblib
import numpy as np
import pandas as pd

# Load the trained model
decision_tree = joblib.load('decision_tree_model.joblib')

# Function to get input from the user
def get_user_input():
    text_size = float(input("Enter the text size (in bits): "))
    image_capacity = float(input("Enter the image capacity (in KB): "))
    psnr = float(input("Enter the PSNR value: "))
    mse = float(input("Enter the MSE value: "))
    ssim = float(input("Enter the SSIM value: "))
    
    # Create a DataFrame with the input values
    input_data = pd.DataFrame({
        'psnr': [psnr],
        'mse': [mse],
        'ssim': [ssim],
        'text_size_bits': [text_size],
        'image_capacity_kb': [image_capacity]
    })
    
    return input_data

# Get input from the user
input_features = get_user_input()

# Predict the quality of the stego image
quality_prediction = decision_tree.predict(input_features)

# Output the result
print(f"The model classifies the stego image as: {quality_prediction[0]}")

# Optional: For more detailed output, you can add a confidence score
proba = decision_tree.predict_proba(input_features)
print(f"Prediction probabilities: {proba}")
