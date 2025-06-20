import pandas as pd
import numpy as np
from skimage.io import imread
from skimage.metrics import peak_signal_noise_ratio as psnr, mean_squared_error as mse, structural_similarity as ssim
from skimage.color import rgb2gray
import os

# Debug flag
DEBUG = True

# Function to remove alpha channel if present
def remove_alpha_channel(image):
    if image.shape[-1] == 4:
        if DEBUG: print("Alpha channel detected and removed.")
        return image[..., :3]
    return image

# Function to calculate quality metrics
def calculate_quality_metrics(original, stego):
    if DEBUG: print("Calculating PSNR, MSE, and SSIM...")
    psnr_value = psnr(original, stego)
    mse_value = mse(original, stego)
    
    # Calculate SSIM based on image type (color or grayscale)
    if original.ndim == 3:
        ssim_value = ssim(original, stego, channel_axis=-1)  # for color images
    else:
        ssim_value = ssim(original, stego)  # for grayscale images
    
    return psnr_value, mse_value, ssim_value

# Function to calculate image capacity in kilobytes
def calculate_image_capacity(image):
    # Assuming LSB steganography, where each pixel can hold 3 bits (1 bit per color channel)
    capacity_bits = image.shape[0] * image.shape[1] * 3
    capacity_kb = capacity_bits / (8 * 1024)
    if DEBUG: print(f"Image capacity calculated: {capacity_kb} KB")
    return capacity_kb

# Function to interactively prepare the dataset
def prepare_dataset():
    data = []
    while True:
        image_type = input("Enter image type (RGB/Grayscale): ").strip()
        text_size_bits = int(input("Enter size of text in bits: ").strip())
        algorithm_used = input("Enter algorithm used (LSB/LSB+AES/LSB+Huffman/LSB+Huffman+AES): ").strip()
        original_image_path = input("Enter path to original image: ").strip()
        stego_image_path = input("Enter path to stego image: ").strip()

        if not os.path.exists(original_image_path) or not os.path.exists(stego_image_path):
            print("One of the image paths does not exist. Please try again.")
            continue

        original_image = imread(original_image_path)
        stego_image = imread(stego_image_path)

        if DEBUG: 
            print(f"Original image dimensions: {original_image.shape}")
            print(f"Stego image dimensions: {stego_image.shape}")

        # Remove alpha channel if present
        original_image = remove_alpha_channel(original_image)
        stego_image = remove_alpha_channel(stego_image)

        if original_image.shape != stego_image.shape:
            print("Error: The original and stego images do not have the same dimensions even after removing alpha channel. Please check your images and try again.")
            continue

        if image_type.lower() == 'grayscale':
            original_image = rgb2gray(original_image)
            stego_image = rgb2gray(stego_image)
            if DEBUG: print("Converted images to grayscale.")

        psnr_value, mse_value, ssim_value = calculate_quality_metrics(original_image, stego_image)
        
        # Display the quality metrics
        print(f"PSNR: {psnr_value}")
        print(f"MSE: {mse_value}")
        print(f"SSIM: {ssim_value}")

        quality_label = input("Enter quality (good/bad): ").strip().lower()
        
        if quality_label not in ['good', 'bad']:
            print("Invalid quality label. Please enter 'good' or 'bad'.")
            continue

        image_capacity_kb = calculate_image_capacity(original_image)
        print(f"Image Capacity: {image_capacity_kb} KB")

        data.append((image_type, text_size_bits, image_capacity_kb, algorithm_used, psnr_value, mse_value, ssim_value, quality_label))

        cont = input("Do you want to add another entry? (yes/no): ").strip().lower()
        if cont != 'yes':
            break

    df = pd.DataFrame(data, columns=['image_type', 'text_size_bits', 'image_capacity_kb', 'algorithm_used', 'psnr', 'mse', 'ssim', 'prediction'])
    
    # Check if the dataset file already exists
    if os.path.exists('dataset.csv'):
        df.to_csv('dataset.csv', mode='a', header=False, index=False)
    else:
        df.to_csv('dataset.csv', index=False)
        
    print("Dataset saved to 'dataset.csv'")

if __name__ == "__main__":
    prepare_dataset()