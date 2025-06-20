import pandas as pd
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
from sklearn.utils import shuffle
import model  # This imports the build_model and save_model functions

# Load the dataset
df = pd.read_csv('C:/Users/rohan/FYP_AI/modified_dataset.csv')

# Features and target variable
X = df[['psnr', 'mse', 'ssim', 'text_size_bits', 'image_capacity_kb']]
y = df['image_quality']

# Split the dataset into train and test sets (80% train, 20% test)
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Build the Random Forest model
random_forest = model.build_model()

# Train the model
random_forest.fit(X_train, y_train)

# Cross-validation to evaluate the model
cv_scores = cross_val_score(random_forest, X_train, y_train, cv=5)
print(f"Cross-validation scores: {cv_scores}")
print(f"Average CV score: {cv_scores.mean()}")

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

# Save the trained model
model.save_model(random_forest)

# Plot metrics on graphs
metrics = ['Accuracy', 'Precision', 'Recall', 'F1 Score']
scores = [accuracy, precision, recall, f1]

# Create a bar chart
plt.figure(figsize=(8, 6))
plt.bar(metrics, scores, color=['blue', 'green', 'red', 'purple'])
plt.ylim([0, 1])
plt.title('Model Performance Metrics')
plt.ylabel('Score')
plt.xlabel('Metrics')
plt.show()

# Line chart
plt.figure(figsize=(8, 6))
plt.plot(metrics, scores, marker='o', color='blue', linestyle='--')
plt.title('Model Performance Metrics')
plt.ylabel('Score')
plt.xlabel('Metrics')
plt.ylim([0, 1])
plt.grid(True)
plt.show()

# Feature Importance Plot
feature_importances = random_forest.feature_importances_
features = ['psnr', 'mse', 'ssim', 'text_size_bits', 'image_capacity_kb']

plt.figure(figsize=(10, 6))
plt.barh(features, feature_importances, color='skyblue')
plt.xlabel('Importance')
plt.title('Feature Importance in Random Forest')
plt.show()