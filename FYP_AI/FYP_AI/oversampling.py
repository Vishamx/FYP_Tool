from imblearn.over_sampling import SMOTE
import model  # This imports your build_model and save_model functions
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
from sklearn.model_selection import train_test_split
import pandas as pd

# Load the dataset
df = pd.read_csv('C:/Users/rohan/FYP_AI/modified_dataset.csv')

# Features and target variable
X = df[['psnr', 'mse', 'ssim', 'text_size_bits', 'image_capacity_kb']]
y = df['image_quality']

# Split the dataset into train and test sets (80% train, 20% test)
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize SMOTE for oversampling the minority classes
sm = SMOTE(random_state=42)

# Apply SMOTE to the training data
X_resampled, y_resampled = sm.fit_resample(X_train, y_train)

# Build and train the random forest model
random_forest = model.build_model()
random_forest.fit(X_resampled, y_resampled)

# Test the model on the test set
y_pred = random_forest.predict(X_test)
accuracy = accuracy_score(y_test, y_pred)
precision = precision_score(y_test, y_pred, average='weighted')
recall = recall_score(y_test, y_pred, average='weighted')
f1 = f1_score(y_test, y_pred, average='weighted')

print(f"Test accuracy: {accuracy}")
print(f"Test precision: {precision}")
print(f"Test recall: {recall}")
print(f"Test F1 score: {f1}")

# Save the trained model as joblib
model.save_model(random_forest)
