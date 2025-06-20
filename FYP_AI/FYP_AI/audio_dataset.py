import pandas as pd
import wave
import os

def get_audio_properties(audio_path):
    """Extracts duration, sample rate, and channels from an audio file."""
    with wave.open(audio_path, 'rb') as audio:
        sample_rate = audio.getframerate()
        channels = audio.getnchannels()
        frames = audio.getnframes()
        duration_in_seconds = frames / float(sample_rate)
    return duration_in_seconds, sample_rate, channels

def main():
    # Get user input
    cover_audio_path = input("Enter the path to the cover audio: ")
    text_size = int(input("Enter the size of embedded text in bits: "))  # Text size in bits

    # Extract audio properties from the cover audio file
    duration, sample_rate, channels = get_audio_properties(cover_audio_path)
    
    # Ask user to select embedding bits per sample (1 bps or 2 bps)
    bits_per_sample = int(input("Enter bits per sample for embedding (1 or 2): "))

    # Calculate the total number of samples and embedding capacity
    total_samples = int(duration * sample_rate * channels)
    embedding_capacity_bits = total_samples * bits_per_sample  # Embedding capacity in bits
    embedding_capacity_bytes = embedding_capacity_bits / 8  # Convert bits to bytes
    embedding_capacity_kb = round(embedding_capacity_bytes / 1024, 1)  # Convert bytes to kilobytes, round to 1 decimal place

    # Prompt user for SNR and MSE values manually
    snr = float(input("Enter the SNR value (from your app): "))
    mse = float(input("Enter the MSE value (from your app): "))

    # Prompt user for Stego Audio Quality classification
    stego_audio_quality = input("Classify the Stego Audio Quality (Good, Acceptable, Bad): ")

    # Prepare data for CSV, including only the specified fields
    results = {
        "Text Size (bits)": text_size,
        "Embedding Capacity (kb)": embedding_capacity_kb,
        "Bps": bits_per_sample, 
        "SNR (dB)": snr,
        "MSE": mse,
        "Stego Audio Quality": stego_audio_quality  # Classification for model
    }
    
    # Save results to CSV, allowing for appending or overwriting
    csv_file = "audio_steganography_results.csv"
    file_exists = os.path.isfile(csv_file)
    
    if not file_exists:
        # Create new file with header
        df = pd.DataFrame([results])
        df.to_csv(csv_file, index=False, mode='w')
    else:
        # Append to existing file without writing header
        df = pd.DataFrame([results])
        df.to_csv(csv_file, index=False, mode='a', header=False)
    
    print("Results saved successfully to", csv_file)

if __name__ == "__main__":
    main()
