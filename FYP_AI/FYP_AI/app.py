from flask import Flask, request, jsonify
import joblib
import numpy as np
import pandas as pd
from werkzeug.exceptions import BadRequest

# Initialize Flask app
app = Flask(__name__)

# Load the pre-trained RandomForest model
model = joblib.load('random_forest_model.joblib')

audio_model = joblib.load('audio_random_forest_model.joblib')

# API route for classification
@app.route('/classify', methods=['POST'])
def classify_image():
    try:
        # Get JSON data from the request
        data = request.get_json()

        # Ensure all required keys are present in the JSON
        required_keys = ['text_size_bits', 'image_capacity_kb', 'psnr', 'mse', 'ssim']
        for key in required_keys:
            if key not in data:
                raise BadRequest(f'Missing required field: {key}')
        
        # Extract the features from the JSON and create a DataFrame
        features = {
            'text_size_bits': [data['text_size_bits']],
            'image_capacity_kb': [data['image_capacity_kb']],
            'psnr': [data['psnr']],
            'mse': [data['mse']],
            'ssim': [data['ssim']]
        }
        
        # Create a DataFrame with the correct feature names
        features_df = pd.DataFrame(features)

        # Predict the class using the loaded model
        prediction = model.predict(features_df)

        # Return the result as a JSON response (raw output)
        return jsonify({'classification': str(prediction[0])})

    except BadRequest as e:
        return jsonify({'error': str(e)}), 400  # Client-side issue
    except Exception as e:
        return jsonify({'error': 'Server Error: ' + str(e)}), 500  # Server-side issue
    
# API route for audio classification
@app.route('/classify-audio', methods=['POST'])
def classify_audio():
    try:
        # Get JSON data from the request
        data = request.get_json()

        # Ensure all required keys are present in the JSON
        required_keys = ['text_size_bits', 'embedding_capacity_kb', 'bps', 'snr', 'mse']
        for key in required_keys:
            if key not in data:
                raise BadRequest(f'Missing required field: {key}')
        
        # Extract the features from the JSON and create a DataFrame
        features = {
            'Text Size (bits)': [data['text_size_bits']],
            'Embedding Capacity (kb)': [data['embedding_capacity_kb']],
            'Bps': [data['bps']],
            'SNR (dB)': [data['snr']],
            'MSE': [data['mse']]
        }
        
        # Create a DataFrame with the correct feature names
        features_df = pd.DataFrame(features)

        # Predict the class using the loaded audio model
        prediction = audio_model.predict(features_df)

        # Return the result as a JSON response (raw output)
        return jsonify({'classification': str(prediction[0])})

    except BadRequest as e:
        return jsonify({'error': str(e)}), 400  # Client-side issue
    except Exception as e:
        return jsonify({'error': 'Server Error: ' + str(e)}), 500  # Server-side issue

# Run the Flask app
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
