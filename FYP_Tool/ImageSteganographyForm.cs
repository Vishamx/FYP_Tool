using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FYP_Tool
{
    public partial class ImageSteganographyForm : Form
    {
        private Bitmap originalImage;
        private Bitmap modifiedImage;
        private Bitmap stegoImage;
        private ImageFormat originalFormat;


        private byte[] secret_key;
        private byte[] iv;
        private string KeyFilePath = "C:\\Users\\rohan\\Desktop\\resultStegoImgsecret_key_iv.txt";

        private Compression.HuffmanNode root;
        private string HuffmanFilePath = "C:\\Users\\rohan\\Desktop\\huffman_root_node.json";

        private double psnr;
        private double mse;
        private double ssim;
        private double imageCapacity;
        private static double textSize;

        public ImageSteganographyForm()
        {
            InitializeComponent();
        }

        public void SetCompressedData(string compressedData)
        {
            embedData_rtb.Text = compressedData;
        }

        public static void settextSize(double ts)
        {
            textSize = ts + 32.0;
        }

        private void chooseCoverImg_button_Click(object sender, EventArgs e)
        {
            openFileDialog_coverImg.ShowDialog();
            string filepath = openFileDialog_coverImg.FileName;
            coverImg_picBox.Image = Image.FromFile(filepath);
            originalImage = (Bitmap)coverImg_picBox.Image;
            originalFormat = GetImageFormat(filepath);
        }

        private ImageFormat GetImageFormat(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Png; // Default to PNG
            }
        }

        private void chooseStegoImg_button_Click(object sender, EventArgs e)
        {
            openFileDialog_stegoImg.ShowDialog();
            string filepath = openFileDialog_stegoImg.FileName;
            stegoImg_picBox.Image = Image.FromFile(filepath);
            stegoImage = (Bitmap)stegoImg_picBox.Image;
        }

        private void embedData_button_Click(object sender, EventArgs e)
        {
            if (originalFormat.Equals(ImageFormat.Jpeg))
            {
                MessageBox.Show("Warning: JPEG images use lossy compression, which may corrupt the embedded data. Please use a lossless format like PNG or BMP for steganography.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string textToEmbed = embedData_rtb.Text;

            // Prompt the user to choose between embedding a string or binary data
            DialogResult result = MessageBox.Show("Embed compressed data?", "Embed Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Convert the string to a binary string
                string bitString = ConvertStringToBinary(textToEmbed);
                modifiedImage = EncodeTextIntoImage(originalImage, bitString);
            }
            else
            {
                // 
                modifiedImage = EncodeTextIntoImage(originalImage, textToEmbed);
            }

            resultStegoImg_picBox.Image = modifiedImage;
            Debug.WriteLine("Embedding completed.");
        }

        // convert string to bhinary fun
        private string ConvertStringToBinary(string data)
        {
            StringBuilder binary = new StringBuilder();
            foreach (char c in data)
            {
                binary.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return binary.ToString();
        }


        private void saveStegoImg_button_Click(object sender, EventArgs e)
        {
            if (originalFormat.Equals(ImageFormat.Png))
            {
                saveFileDialog_resultStegoImg.Filter = "PNG Image|*.png";
            }

            else if (originalFormat.Equals(ImageFormat.Bmp))
            {
                saveFileDialog_resultStegoImg.Filter = "BMP Image|*.bmp";
            }
            else
            {
                saveFileDialog_resultStegoImg.Filter = "PNG Image|*.png"; // Default to PNG
            }

            if (saveFileDialog_resultStegoImg.ShowDialog() == DialogResult.OK)
            {
                modifiedImage.Save(saveFileDialog_resultStegoImg.FileName, originalFormat);
                MessageBox.Show("Modified image saved successfully");
            }
        }

        private void extractData_button_Click(object sender, EventArgs e)
        {
            if (stegoImage == null)
            {
                MessageBox.Show("No image chosen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string decodedText;
            int numBits = GetEmbeddedDataLength(stegoImage);
            DialogResult result = MessageBox.Show("Would you like to extract compressed data?", "Embed Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                decodedText = DecodeTextFromImage(stegoImage, numBits);
            }

            else
            {
                decodedText = DecodeTextFromImage(stegoImage, numBits);
                decodedText = ConvertBinaryToString(decodedText);
            }

            extractedData_rtb.Text = decodedText;
        }

        // Helper function to convert a binary string back to a readable string
        private string ConvertBinaryToString(string binaryData)
        {
            List<byte> byteList = new List<byte>();

            for (int i = 0; i < binaryData.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binaryData.Substring(i, 8), 2));
            }

            return Encoding.UTF8.GetString(byteList.ToArray());
        }

        private Bitmap EncodeTextIntoImage(Bitmap image, string bitString)
        {
            Bitmap newImage = new Bitmap(image);
            int totalCapacityBits = image.Width * image.Height * 3;

            // Convert the length of the bitString to a 32-bit binary string and prepend it to the bitString
            string lengthBitString = Convert.ToString(bitString.Length, 2).PadLeft(32, '0');
            bitString = lengthBitString + bitString;

            if (bitString.Length > totalCapacityBits)
            {
                throw new Exception("The data to embed exceeds the image's embedding capacity.");
            }

            int bitIndex = 0;

            Debug.WriteLine("Starting embedding process...");

            // Sequentially iterate over each pixel
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (bitIndex >= bitString.Length)
                    {
                        Debug.WriteLine($"Finished embedding at pixel [{x},{y}]."); //used only in debug mode
                        return newImage;
                    }

                    Color pixel = newImage.GetPixel(x, y);

                    // Embed one bit in each color channel (R, G, B) and log the process.
                    int r = pixel.R & 0xFE | (bitIndex < bitString.Length ? bitString[bitIndex++] - '0' : 0);
                    Debug.WriteLine($"Embedding bit {bitIndex} at [{x},{y}] (R channel): {r & 1}");

                    int g = pixel.G & 0xFE | (bitIndex < bitString.Length ? bitString[bitIndex++] - '0' : 0);
                    Debug.WriteLine($"Embedding bit {bitIndex} at [{x},{y}] (G channel): {g & 1}");

                    int b = pixel.B & 0xFE | (bitIndex < bitString.Length ? bitString[bitIndex++] - '0' : 0);
                    Debug.WriteLine($"Embedding bit {bitIndex} at [{x},{y}] (B channel): {b & 1}");

                    
                    newImage.SetPixel(x, y, Color.FromArgb(r, g, b));

                    // check if all bits are being embedded.
                    Debug.WriteLine($"Pixel [{x},{y}] updated: R={r & 1}, G={g & 1}, B={b & 1}");
                }
            }


            return newImage;
        }

        private string DecodeTextFromImage(Bitmap image, int numBits)
        {
            StringBuilder bitString = new StringBuilder();
            int bitIndex = 0;

            Debug.WriteLine("Starting extraction process...");

            // Sequentially iterate over each pixel (same order as embedding)
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (bitIndex >= numBits + 32)
                    {
                        Debug.WriteLine("Finished extracting all bits.");
                        return bitString.ToString().Substring(32, numBits);
                    }

                    Color pixel = image.GetPixel(x, y);

                    // Extract one bit from each color channel (R, G, B)
                    bitString.Append(pixel.R & 1);
                    bitIndex++;

                    if (bitIndex >= numBits + 32) break;

                    bitString.Append(pixel.G & 1);
                    bitIndex++;

                    if (bitIndex >= numBits + 32) break;

                    bitString.Append(pixel.B & 1);
                    bitIndex++;
                }

                if (bitIndex >= numBits + 32)
                {
                    break;
                }
            }

            Debug.WriteLine("Finished extraction process.");


            if (bitString.Length < numBits + 32)
            {
                throw new Exception("Extracted bit string is shorter than expected. Possible data corruption or incorrect numBits.");
            }

            // Remove the first 32 bits (length information) from the extracted bit string to diplay the embedded message
            return bitString.ToString().Substring(32, numBits);
        }

        private void decompressData_button_Click(object sender, EventArgs e)
        {
            root = DataCompressionForm.LoadHuffmanRootNode(HuffmanFilePath);
            if (root == null)
            {
                MessageBox.Show("Warning: Huffman root node is missing. Please load the Huffman root node before decompression.", "Missing Root Node", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string compressedData = extractedData_rtb.Text;

            string decompressedData = Compression.Decompress(compressedData, root); // Pass the root node for decompression

            decompressedData_rtb.Text = decompressedData;
        }


        private void decryptData_button_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptionForm.LoadSecretKeyAndIV(KeyFilePath, out secret_key, out iv); // Reads the secret key and IV from the file

                if (secret_key == null || iv == null)
                {
                    MessageBox.Show("Warning: Secret key and IV not loaded. Please load the " +
                        "secret key and IV before decryption.", "Missing secret key and IV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                if (!string.IsNullOrWhiteSpace(decompressedData_rtb.Text))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(decompressedData_rtb.Text);
                    string decryptedText = AES.decrypt(encryptedBytes, secret_key, iv);
                    originalData_rtb.Text = decryptedText;
                }
                else
                {
                    byte[] encryptedBytes = Convert.FromBase64String(extractedData_rtb.Text);
                    string decryptedText = AES.decrypt(encryptedBytes, secret_key, iv);
                    originalData_rtb.Text = decryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void calculateMetrics_button_Click(object sender, EventArgs e)
        {
            if (originalImage == null || modifiedImage == null)
            {
                MessageBox.Show("Both images must be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                mse = CalculateMSE(originalImage, modifiedImage);
                psnr = CalculatePSNR(originalImage, modifiedImage);
                ssim = CalculateSSIM(originalImage, modifiedImage);

                MessageBox.Show($"MSE: {mse}\nPSNR: {psnr}\nSSIM: {ssim}", "Image Metrics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateMSE(Bitmap img1, Bitmap img2)
        {
            if (img1.Width != img2.Width || img1.Height != img2.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            double mse = 0.0;
            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    Color p1 = img1.GetPixel(x, y);
                    Color p2 = img2.GetPixel(x, y);
                    mse += Math.Pow(p1.R - p2.R, 2) + Math.Pow(p1.G - p2.G, 2) + Math.Pow(p1.B - p2.B, 2);
                }
            }

            mse /= (img1.Width * img1.Height * 3);
            return mse;
        }

        private double CalculatePSNR(Bitmap img1, Bitmap img2)
        {
            double mse = CalculateMSE(img1, img2);
            if (mse == 0) return double.PositiveInfinity;
            return 20 * Math.Log10(255.0 / Math.Sqrt(mse));
        }

        private double CalculateSSIM(Bitmap img1, Bitmap img2)
        {
            if (img1.Width != img2.Width || img1.Height != img2.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            const double K1 = 0.01;
            const double K2 = 0.03;
            const int L = 255;

            double C1 = (K1 * L) * (K1 * L);
            double C2 = (K2 * L) * (K2 * L);

            int windowSize = 7;
            int windowArea = windowSize * windowSize; // Precompute this value
            double ssimSum = 0.0;
            int count = 0;

            for (int y = 0; y < img1.Height - windowSize + 1; y++)
            {
                for (int x = 0; x < img1.Width - windowSize + 1; x++)
                {
                    double mu1_R = 0.0, mu1_G = 0.0, mu1_B = 0.0;
                    double mu2_R = 0.0, mu2_G = 0.0, mu2_B = 0.0;

                    // Calculate means
                    for (int j = 0; j < windowSize; j++)
                    {
                        for (int i = 0; i < windowSize; i++)
                        {
                            Color p1 = img1.GetPixel(x + i, y + j);
                            Color p2 = img2.GetPixel(x + i, y + j);

                            mu1_R += p1.R;
                            mu1_G += p1.G;
                            mu1_B += p1.B;

                            mu2_R += p2.R;
                            mu2_G += p2.G;
                            mu2_B += p2.B;
                        }
                    }

                    
                    mu1_R /= windowArea;
                    mu1_G /= windowArea;
                    mu1_B /= windowArea;

                    mu2_R /= windowArea;
                    mu2_G /= windowArea;
                    mu2_B /= windowArea;

                    double sigma1_R = 0.0, sigma1_G = 0.0, sigma1_B = 0.0;
                    double sigma2_R = 0.0, sigma2_G = 0.0, sigma2_B = 0.0;
                    double sigma12_R = 0.0, sigma12_G = 0.0, sigma12_B = 0.0;

                    
                    for (int j = 0; j < windowSize; j++)
                    {
                        for (int i = 0; i < windowSize; i++)
                        {
                            Color p1 = img1.GetPixel(x + i, y + j);
                            Color p2 = img2.GetPixel(x + i, y + j);

                            sigma1_R += (p1.R - mu1_R) * (p1.R - mu1_R);
                            sigma1_G += (p1.G - mu1_G) * (p1.G - mu1_G);
                            sigma1_B += (p1.B - mu1_B) * (p1.B - mu1_B);

                            sigma2_R += (p2.R - mu2_R) * (p2.R - mu2_R);
                            sigma2_G += (p2.G - mu2_G) * (p2.G - mu2_G);
                            sigma2_B += (p2.B - mu2_B) * (p2.B - mu2_B);

                            sigma12_R += (p1.R - mu1_R) * (p2.R - mu2_R);
                            sigma12_G += (p1.G - mu1_G) * (p2.G - mu2_G);
                            sigma12_B += (p1.B - mu1_B) * (p2.B - mu2_B);
                        }
                    }

                    
                    double adjustedArea = windowArea - 1;
                    sigma1_R /= adjustedArea;
                    sigma1_G /= adjustedArea;
                    sigma1_B /= adjustedArea;

                    sigma2_R /= adjustedArea;
                    sigma2_G /= adjustedArea;
                    sigma2_B /= adjustedArea;

                    sigma12_R /= adjustedArea;
                    sigma12_G /= adjustedArea;
                    sigma12_B /= adjustedArea;

                    // Calculate SSIM for each channel
                    double ssim_R = ((2 * mu1_R * mu2_R + C1) * (2 * sigma12_R + C2)) /
                                    ((mu1_R * mu1_R + mu2_R * mu2_R + C1) * (sigma1_R + sigma2_R + C2));

                    double ssim_G = ((2 * mu1_G * mu2_G + C1) * (2 * sigma12_G + C2)) /
                                    ((mu1_G * mu1_G + mu2_G * mu2_G + C1) * (sigma1_G + sigma2_G + C2));

                    double ssim_B = ((2 * mu1_B * mu2_B + C1) * (2 * sigma12_B + C2)) /
                                    ((mu1_B * mu1_B + mu2_B * mu2_B + C1) * (sigma1_B + sigma2_B + C2));

                    ssimSum += (ssim_R + ssim_G + ssim_B) / 3.0;
                    count++;
                }
            }

            return ssimSum / count;
        }



        private void showEmbedData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(embedData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void showFullExtractedData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(extractedData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void showFullDecompressedData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(decompressedData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void showFullOriginalData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(originalData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void calcImageCap_button_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("No image chosen. Please select a cover image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isGrayscale = true;

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = ((Bitmap)originalImage).GetPixel(x, y);
                    if (pixelColor.R != pixelColor.G || pixelColor.R != pixelColor.B)
                    {
                        isGrayscale = false;
                        break;
                    }
                }
                if (!isGrayscale) break;
            }

            int totalPixels = originalImage.Width * originalImage.Height;
            int bitsPerPixel = isGrayscale ? 1 : 3; // Grayscale uses 1 bit per pixel, RGB uses 3 bits per pixel
            int totalCapacityBits = totalPixels * bitsPerPixel;
            double totalCapacityBytes = totalCapacityBits / 8.0;
            double totalCapacityKilobytes = totalCapacityBytes / 1024.0;
            imageCapacity = (totalCapacityKilobytes);

            string colorMode = isGrayscale ? "Grayscale" : "RGB";
            MessageBox.Show($"Image Capacity for {colorMode} Image:\n\nBits: {totalCapacityBits}\nBytes: {totalCapacityBytes:F2}\nKilobytes: {totalCapacityKilobytes:F2}",
                            "Image Capacity", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private int GetEmbeddedDataLength(Bitmap image)
        {
            StringBuilder lengthBits = new StringBuilder();
            int bitIndex = 0;

            // Sequentially iterate over each pixel (same order as embedding)
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (bitIndex >= 32)
                    {
                        return Convert.ToInt32(lengthBits.ToString(), 2);
                    }

                    Color pixel = image.GetPixel(x, y);

                    // Extract one bit from each color channel (R, G, B)
                    lengthBits.Append(pixel.R & 1);
                    bitIndex++;

                    if (bitIndex >= 32) break;
                    lengthBits.Append(pixel.G & 1);
                    bitIndex++;

                    if (bitIndex >= 32) break;
                    lengthBits.Append(pixel.B & 1);
                    bitIndex++;
                }

                if (bitIndex >= 32)
                {
                    break;
                }
            }

            return Convert.ToInt32(lengthBits.ToString(), 2);
        }

        private async void classify_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt the user to input the text size
                //string inputTextSize = Microsoft.VisualBasic.Interaction.InputBox("Enter the text size in bits:", "Input Text Size", "0");
                string textSizeString = textSize.ToString();
                MessageBox.Show("Text size: " + textSizeString);

                // Validate the text size input
                //if (string.IsNullOrEmpty(inputTextSize) || !double.TryParse(inputTextSize, out double textSize))
                //{
                //    MessageBox.Show("Invalid text size entered. Please enter a valid number.");
                //    return;
                //}

                

                // Disable the classify button and change the button text to indicate processing
                classify_button.Enabled = false;
                classify_button.Text = "Classifying...";

                // Instantiate the Classifier class and call the prediction function with saved field values
                Classifier classifier = new Classifier();
                if(imageCapacity == 0.0)
                {
                    MessageBox.Show("Need value of embedding capacity ");
                    return;
                }
                string prediction = await classifier.GetPredictionAsync(textSize, imageCapacity, psnr, mse, ssim);

                // Show the prediction result in a message box
                MessageBox.Show($"The model classifies the stego image as: {prediction}");
            }
            catch (Exception ex)
            {
                // Display any error that occurs during the process
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Reset the classify button once classification is done
                classify_button.Text = "Classify";
                classify_button.Enabled = true;
            }
        }
    }
}
