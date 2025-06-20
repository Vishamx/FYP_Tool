using NAudio.Gui;
using NAudio.Wave;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace FYP_Tool
{
    public partial class AudioSteganographyForm : Form
    {
        private WaveFileReader waveFileReader;
        private WaveOutEvent waveOut;
        private byte[] modifiedAudioData;
        private WaveFileReader modifiedWaveFileReader;
        private WaveOutEvent modifiedWaveOut;
        private string savedModifiedAudioPath;
        private string loadedStegoAudioPath; // Store the file path of the loaded stego audio
        private const int seed = 12345; // Fixed seed value

        private byte[] secret_key;
        private byte[] iv;
        private string KeyFilePath = "C:\\Users\\rohan\\Desktop\\resultStegoImgsecret_key_iv.txt";

        private Compression.HuffmanNode root;
        private string HuffmanFilePath = "C:\\Users\\rohan\\Desktop\\huffman_root_node.json";

        private double totalBitsAvailable;
        private double snr;
        private double mse;
        private double embeddingCapacity;
        private double bps;
        private static double textSize;


        public AudioSteganographyForm()
        {
            InitializeComponent();
        }

        public void SetCompressedData(string encryptedData)
        {
            embedData_rtb.Text = encryptedData;
        }

        public static void setAudioTextSize(double ts)
        {
            textSize = ts + 32.0;
        }

        private void chooseCoverAud_button_Click(object sender, EventArgs e)
        {
            // Allow the user to select any file type by using the "All Files" filter.
            openFileDialog_coverAud.Filter = "All Files (*.*)|*.*";

            if (openFileDialog_coverAud.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog_coverAud.FileName;

                // Check if the file is a WAV file
                if (Path.GetExtension(filepath).ToLower() != ".wav")
                {
                    // Issue a warning if the selected file is not a WAV file
                    MessageBox.Show("This application currently supports only WAV file. Please choose a WAV file.",
                                    "Unsupported File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Exit the function without processing the non-WAV file
                }

                // If the file is a valid WAV file, proceed with displaying it
                displayCoverAud_tb.Text = Path.GetFileName(filepath);
                displayCoverAud_tb.Enabled = false;

                waveFileReader = new WaveFileReader(filepath);
            }
        }


        private void playCoverAud_button_Click(object sender, EventArgs e)
        {
            if (waveFileReader != null)
            {
                waveOut = new WaveOutEvent();
                waveOut.Init(waveFileReader);
                waveOut.Play();
            }
            else
            {
                MessageBox.Show("Please load a cover audio file first.");
            }
        }

        private void stopCoverAud_button_Click(object sender, EventArgs e)
        {
            waveOut?.Stop();
        }

        private void embedData_button_Click(object sender, EventArgs e)
        {
            if (waveFileReader == null)
            {
                MessageBox.Show("Please choose a cover audio file first.");
                return;
            }

            var binaryData = embedData_rtb.Text;
            if (string.IsNullOrEmpty(binaryData))
            {
                MessageBox.Show("Please enter the binary data or string to embed.");
                return;
            }

            // Ask if the text is in string format
            DialogResult isStringResult = MessageBox.Show("Embed compressed data?", "Embedding Option", MessageBoxButtons.YesNo);
            if (isStringResult == DialogResult.No)
            {
                // Convert the string to binary
                binaryData = StringToBinary(embedData_rtb.Text);
            }

            // Ask if embedding should be done as 1 bps or 2 bps
            DialogResult bpsResult = MessageBox.Show("Embed as 1 bps or 2 bps?", "Embedding Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            bool embedAs2Bps = (bpsResult == DialogResult.No); // No means 2 bps, Yes means 1 bps

            if (bpsResult == DialogResult.Yes)
            {
                bps = 1; // Yes means 1 bps
            }
            else
            {
                bps = 2; // No means 2 bps
            }

            try
            {
                byte[] audioData;
                using (var memoryStream = new MemoryStream())
                {
                    waveFileReader.Position = 0; // Reset to the beginning of the file
                    waveFileReader.CopyTo(memoryStream);
                    audioData = memoryStream.ToArray();
                }



                if (binaryData.Length > totalBitsAvailable)
                {
                    MessageBox.Show("Data size exceeds embedding capacity.", "Error");
                    return;
                }


                // Embed based on the user's choice
                if (embedAs2Bps)
                {
                    modifiedAudioData = EmbedBinaryMessage2Bps(audioData, binaryData);
                }
                else
                {
                    modifiedAudioData = EmbedBinaryMessage1Bps(audioData, binaryData);
                }

                displayStegoAud_tb.Text = displayCoverAud_tb.Text + "_modifiedAudio.wav";
                displayCoverAud_tb.Enabled = false;
                MessageBox.Show("Data embedded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error embedding data: " + ex.Message);
            }
        }


        // Function to convert string to binary (ASCII-based)
        private static string StringToBinary(string data)
        {
            string binaryString = "";
            foreach (char c in data)
            {
                binaryString += Convert.ToString(c, 2).PadLeft(8, '0'); // Convert each character to 8-bit binary
            }
            return binaryString;
        }


        private static byte[] EmbedBinaryMessage1Bps(byte[] audioBytes, string binaryMessage)
        {
            // Convert the length of the message to binary and prepend it to the message
            string binaryLength = Convert.ToString(binaryMessage.Length, 2).PadLeft(32, '0'); // 32-bit integer
            binaryMessage = binaryLength + binaryMessage;

            int byteIndex = 44; // Skip the WAV header
            int bitIndex = 0;

            while (bitIndex < binaryMessage.Length)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Message is too long to hide in the audio file.");
                }

                // Log the bit being embedded
                Debug.WriteLine($"Embedding bit {bitIndex + 1}: {binaryMessage[bitIndex]}");

                // Modify the LSB of the audio byte to embed the bit
                audioBytes[byteIndex] = (byte)((audioBytes[byteIndex] & 0xFE) | (binaryMessage[bitIndex] - '0'));

                bitIndex++;
                byteIndex++;
            }

            return audioBytes;
        }

        //embed func for 2bps

        private static byte[] EmbedBinaryMessage2Bps(byte[] audioBytes, string binaryMessage)
        {
            // Convert the length of the message to binary and prepend it to the message
            string binaryLength = Convert.ToString(binaryMessage.Length, 2).PadLeft(32, '0'); // 32-bit integer
            binaryMessage = binaryLength + binaryMessage;

            int byteIndex = 44; // Skip the WAV header
            int bitIndex = 0;

            while (bitIndex < binaryMessage.Length)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Message is too long to hide in the audio file.");
                }

                // Embed 2 bps (both LSB and the second LSB)
                if (bitIndex + 1 < binaryMessage.Length)
                {
                    // Extract 2 bits from the msg
                    int bit1 = binaryMessage[bitIndex] - '0';
                    int bit2 = binaryMessage[bitIndex + 1] - '0';

                    // Modify both the LSB and the second LSB
                    byte newByte = (byte)((audioBytes[byteIndex] & 0xFC) | (bit1 << 1) | bit2);
                    audioBytes[byteIndex] = newByte;

                    // Log the bits being embedded
                    Debug.WriteLine($"Embedding bits {bitIndex + 1} and {bitIndex + 2}: {bit1}{bit2} into byte index {byteIndex}");

                    // Move to the next 2 bits in the msg
                    bitIndex += 2;
                }
                else
                {
                    // Embed the last single bit if the binary message length is odd
                    int bit1 = binaryMessage[bitIndex] - '0';
                    audioBytes[byteIndex] = (byte)((audioBytes[byteIndex] & 0xFE) | bit1);

                    // Log the single bit being embedded
                    Debug.WriteLine($"Embedding bit {bitIndex + 1}: {bit1} into byte index {byteIndex}");

                    bitIndex++;
                }

                byteIndex++;
            }

            return audioBytes;
        }



        private void saveStegoAud_button_Click(object sender, EventArgs e)
        {
            if (modifiedAudioData == null)
            {
                MessageBox.Show("No modified audio data to save.");
                return;
            }

            saveFileDialog_resultStegoAud.Filter = "WAV files (*.wav)|*.wav";
            if (saveFileDialog_resultStegoAud.ShowDialog() == DialogResult.OK)
            {
                savedModifiedAudioPath = saveFileDialog_resultStegoAud.FileName;
                try
                {
                    using (var memoryStream = new MemoryStream(modifiedAudioData))
                    {
                        var waveFormat = waveFileReader.WaveFormat;
                        using (var waveFileWriter = new WaveFileWriter(savedModifiedAudioPath, waveFormat))
                        {
                            waveFileWriter.Write(modifiedAudioData, 0, modifiedAudioData.Length);
                        }
                    }
                    MessageBox.Show("Modified audio saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving modified audio: " + ex.Message);
                }
            }
        }

        private static string ExtractBinaryMessageSequentially(byte[] audioBytes)
        {
            int byteIndex = 44; // Skip the WAV header

            // Extract the length of the embedded message (32 bits)
            char[] binaryLengthChars = new char[32];
            for (int i = 0; i < 32; i++)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Unexpected end of audio data while extracting length.");
                }

                binaryLengthChars[i] = (char)((audioBytes[byteIndex] & 0x01) + '0');
                byteIndex++;
            }

            int messageLength = Convert.ToInt32(new string(binaryLengthChars), 2);

            // Extract the message
            char[] binaryMessage = new char[messageLength];
            for (int bitIndex = 0; bitIndex < messageLength; bitIndex++)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Unexpected end of audio data while extracting message.");
                }

                binaryMessage[bitIndex] = (char)((audioBytes[byteIndex] & 0x01) + '0');
                byteIndex++;
            }

            return new string(binaryMessage);
        }


        //2bps extract funct

        private static string ExtractBinaryMessageWith2Bps(byte[] audioBytes)
        {
            int byteIndex = 44; // Skip the WAV header

            // Step 1: Extract the length of the embedded message (32 bits, using 2 bits per byte)
            char[] binaryLengthChars = new char[32];
            int bitIndex = 0;

            // Extract the message length using 2 bits per byte
            while (bitIndex < 32)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Unexpected end of audio data while extracting length.");
                }

                // Extract 2 bits for the message length
                int bit1 = (audioBytes[byteIndex] >> 1) & 0x01; // Second least significant bit
                int bit2 = audioBytes[byteIndex] & 0x01;         // Least significant bit

                binaryLengthChars[bitIndex] = (char)(bit1 + '0');
                binaryLengthChars[bitIndex + 1] = (char)(bit2 + '0');

                // Move to the next byte and increment bit index by 2
                byteIndex++;
                bitIndex += 2;
            }

            // Convert the binary length string to an integer
            int messageLength = Convert.ToInt32(new string(binaryLengthChars), 2);

            // Sanity check: Ensure that the messageLength is within valid bounds
            int maxPossibleLength = (audioBytes.Length - 44) * 2; // Maximum possible bits that can be embedded
            if (messageLength <= 0 || messageLength > maxPossibleLength)
            {
                throw new Exception($"Invalid message length extracted: {messageLength} bits. Max possible length is {maxPossibleLength} bits.");
            }

            Debug.WriteLine($"Extracted message length: {messageLength} bits");

            // Step 2: Extract the actual message based on the extracted length
            char[] binaryMessage = new char[messageLength];
            bitIndex = 0;

            while (bitIndex < messageLength)
            {
                if (byteIndex >= audioBytes.Length)
                {
                    throw new Exception("Unexpected end of audio data while extracting message.");
                }

                // Extract 2 bits per sample from the LSB and second LSB
                int bit1 = (audioBytes[byteIndex] >> 1) & 0x01; // Second least significant bit
                binaryMessage[bitIndex] = (char)(bit1 + '0');

                if (bitIndex + 1 < messageLength)
                {
                    int bit2 = audioBytes[byteIndex] & 0x01; // Least significant bit
                    binaryMessage[bitIndex + 1] = (char)(bit2 + '0');

                    // Log both bits extracted
                    Debug.WriteLine($"Extracting bits {bitIndex + 1} and {bitIndex + 2}: {bit1}{bit2} from byte index {byteIndex}");

                    bitIndex += 2; // Move to the next 2 bits
                }
                else
                {
                    // Log the single bit extracted
                    Debug.WriteLine($"Extracting bit {bitIndex + 1}: {bit1} from byte index {byteIndex}");
                    bitIndex++; // Only one bit left to process
                }

                byteIndex++;
            }

            return new string(binaryMessage);
        }








        private void showEmbedData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(embedData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void playStegoAud_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savedModifiedAudioPath))
            {
                MessageBox.Show("No modified audio file found to play.");
                return;
            }

            try
            {
                modifiedWaveFileReader = new WaveFileReader(savedModifiedAudioPath);
                modifiedWaveOut = new WaveOutEvent();
                modifiedWaveOut.Init(modifiedWaveFileReader);
                modifiedWaveOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing modified audio: " + ex.Message);
            }
        }

        private void stopStegoAud_button_Click(object sender, EventArgs e)
        {
            modifiedWaveOut?.Stop();
        }

        private void calcAvailableBits_button_Click(object sender, EventArgs e)
        {
            if (waveFileReader == null)
            {
                MessageBox.Show("Please choose a cover audio file first.");
                return;
            }

            try
            {
                // Step 1: Get duration, sample rate, channels, and bit depth
                var durationInSeconds = waveFileReader.TotalTime.TotalSeconds;
                var sampleRate = waveFileReader.WaveFormat.SampleRate;
                var channels = waveFileReader.WaveFormat.Channels;
                var bitDepth = waveFileReader.WaveFormat.BitsPerSample;

                // Display the audio bit depth first
                //MessageBox.Show($"Audio Bit Depth: {bitDepth} bits", "Audio Information");

                // Step 2: Ask if embedding should be done using 1 bps or 2 bps
                DialogResult result = MessageBox.Show("Calculate embedding capacity for 1 bps or 2bps?", "Embedding Capacity",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                // Yes -> 1 bps, No -> 2 bps
                int bitsPerSample = (result == DialogResult.Yes) ? 1 : 2;

                // Step 3: Calculate the total number of samples
                var totalSamples = (int)(durationInSeconds * sampleRate * channels);

                // Embedding capacity: bitsPerSample bit(s) per sample
                totalBitsAvailable = totalSamples * bitsPerSample;

                // Convert to bytes and kilobytes
                var totalBytesAvailable = totalBitsAvailable / 8; // 8 bits = 1 byte
                var totalKilobytesAvailable = totalBytesAvailable / 1024.0; // 1024 bytes = 1 kilobyte
                embeddingCapacity = totalKilobytesAvailable; //ai parameter


                MessageBox.Show($"Embedding Capacity ({bitsPerSample} bps):\n" +
                                $"{totalBitsAvailable} bits\n" +
                                $"{totalBytesAvailable} bytes\n" +
                                $"{totalKilobytesAvailable:F2} KB", "Embedding Capacity");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating available bits: " + ex.Message);
            }
        }





        private void chooseStegoAud_button_Click(object sender, EventArgs e)
        {
            openFileDialog_stegoAud.Filter = "WAV files (*.wav)|*.wav";
            if (openFileDialog_stegoAud.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog_stegoAud.FileName;
                displayStegoAud_tb_extrctTab.Text = Path.GetFileName(filepath);
                displayStegoAud_tb_extrctTab.Enabled = false;

                loadedStegoAudioPath = filepath; // Store the file path
                modifiedWaveFileReader = new WaveFileReader(filepath);

                // Load the entire audio data into modifiedAudioData
                using (var memoryStream = new MemoryStream())
                {
                    modifiedWaveFileReader.CopyTo(memoryStream);
                    modifiedAudioData = memoryStream.ToArray();
                }
            }
        }

        private void playStegoAud_button_extrctTab_Click(object sender, EventArgs e)
        {
            try
            {
                modifiedWaveFileReader = new WaveFileReader(loadedStegoAudioPath); // Ensure this is initialized correctly
                modifiedWaveOut = new WaveOutEvent();
                modifiedWaveOut.Init(modifiedWaveFileReader);
                modifiedWaveOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing modified audio: " + ex.Message);
            }
        }

        private void extractEmbeddedData_btn_Click(object sender, EventArgs e)
        {
            if (modifiedWaveFileReader == null || string.IsNullOrEmpty(loadedStegoAudioPath))
            {
                MessageBox.Show("Please load a stego audio file first.");
                return;
            }

            try
            {
                // Ensure modifiedAudioData is populated
                if (modifiedAudioData == null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        modifiedWaveFileReader.CopyTo(memoryStream);
                        modifiedAudioData = memoryStream.ToArray();
                    }
                }



                // Ask if the data should be extracted as 1 bps or 2 bps
                DialogResult bpsResult = MessageBox.Show("Extract as 1 bps or 2 bps?", "Extraction Option", MessageBoxButtons.YesNo);
                bool extractAs2Bps = (bpsResult == DialogResult.No); // No means 2 bps, Yes means 1 bps

                // Extract the binary message based on the user's choice
                string extractedBinaryMessage;
                if (extractAs2Bps)
                {
                    extractedBinaryMessage = ExtractBinaryMessageWith2Bps(modifiedAudioData);
                }
                else
                {
                    extractedBinaryMessage = ExtractBinaryMessageSequentially(modifiedAudioData); // 1 bps extraction
                }

                // Ask if the extracted data is a string
                DialogResult result = MessageBox.Show("Extract compressed data?", "Extraction Option", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    // Convert binary back to string
                    extractedBinaryMessage = BinaryToString(extractedBinaryMessage);
                }

                // Display the extracted message
                extractedData_rtb_extrctTab.Text = extractedBinaryMessage;
                //MessageBox.Show($"Extracted Message: {extractedBinaryMessage}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting binary data: " + ex.Message);
            }
        }


        // Function to convert binary to string (ASCII-based)
        private static string BinaryToString(string binaryData)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binaryData.Length; i += 8)
            {
                string byteString = binaryData.Substring(i, 8); // Take each 8-bit chunk
                list.Add(Convert.ToByte(byteString, 2)); // Convert the 8-bit chunk to a byte
            }

            return System.Text.Encoding.ASCII.GetString(list.ToArray()); // Convert byte array to string
        }


        private void stopStegoAud_button_extractTab_Click(object sender, EventArgs e)
        {
            modifiedWaveOut?.Stop();
        }

        private void decompressData_button_extrctTab_Click(object sender, EventArgs e)
        {
            root = DataCompressionForm.LoadHuffmanRootNode(HuffmanFilePath);

            if (root == null)
            {
                MessageBox.Show("Warning: Huffman root node is missing. Please load the Huffman root node before decompression.", "Missing Root Node", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string compressedData = extractedData_rtb_extrctTab.Text;

            string decompressedData = Compression.Decompress(compressedData, root); // Pass the root node for decompression

            decompressedData_rtb_extrctTab.Text = decompressedData;
        }


        private void decryptData_button_extrctTab_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptionForm.LoadSecretKeyAndIV(KeyFilePath, out secret_key, out iv);

                if (secret_key == null || iv == null)
                {
                    MessageBox.Show("Warning: Secret key and IV not loaded. Please load the secret key and IV before decryption.", "Missing secret key and IV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(decompressedData_rtb_extrctTab.Text))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(decompressedData_rtb_extrctTab.Text);
                    string decryptedText = AES.decrypt(encryptedBytes, secret_key, iv);
                    decryptedData_rtb_extrctTab.Text = decryptedText;
                }
                else
                {
                    byte[] encryptedBytes = Convert.FromBase64String(extractedData_rtb_extrctTab.Text);
                    string decryptedText = AES.decrypt(encryptedBytes, secret_key, iv);
                    decryptedData_rtb_extrctTab.Text = decryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void showFulldisplayStegoAud_tb_extrctTab_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(displayStegoAud_tb_extrctTab.Text);
        }

        private void showFullextractedData_rtb_extrctTab_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(extractedData_rtb_extrctTab.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void showFulldecompressedData_rtb_extrctTab_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(decompressedData_rtb_extrctTab.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void showFulldecryptedData_rtb_extrctTab_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(decryptedData_rtb_extrctTab.Text))
            {
                viewer.ShowDialog();
            }
        }

        private void calcAudQualityMetrics_button_Click(object sender, EventArgs e)
        {
            if (waveFileReader == null || (modifiedAudioData == null && modifiedWaveFileReader == null))
            {
                MessageBox.Show("Please load both the original and stego audio files first.");
                return;
            }

            try
            {
                // Read original audio data
                byte[] originalAudioData;
                using (var memoryStream = new MemoryStream())
                {
                    waveFileReader.Position = 0; // Reset to the beginning of the file
                    waveFileReader.CopyTo(memoryStream);
                    originalAudioData = memoryStream.ToArray();
                }

                // Read modified (stego) audio data
                byte[] stegoAudioData;
                if (modifiedAudioData != null)
                {
                    // Use in-memory modified audio data if available
                    stegoAudioData = modifiedAudioData;
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        modifiedWaveFileReader.Position = 0; // Reset to the beginning of the file
                        modifiedWaveFileReader.CopyTo(memoryStream);
                        stegoAudioData = memoryStream.ToArray();
                    }
                }

                // Ensure both audio files have the same length
                if (originalAudioData.Length != stegoAudioData.Length)
                {
                    MessageBox.Show("The original and stego audio files have different lengths.");
                    return;
                }

                // Calculate SNR
                 snr = CalculateSNR(originalAudioData, stegoAudioData);

                // Calculate MSE
                 mse = CalculateMSE(originalAudioData, stegoAudioData);

                // Display the results
                MessageBox.Show($"SNR: {snr:F2} dB\nMSE: {mse:F6}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating audio quality metrics: " + ex.Message);
            }
        }


        private double CalculateSNR(byte[] originalAudio, byte[] stegoAudio)
        {
            double signalPower = 0.0;
            double noisePower = 0.0;

            for (int i = 0; i < originalAudio.Length; i++)
            {
                signalPower += originalAudio[i] * originalAudio[i];
                double noise = originalAudio[i] - stegoAudio[i];
                noisePower += noise * noise;
            }

            return 10 * Math.Log10(signalPower / noisePower);
        }

        private double CalculateMSE(byte[] originalAudio, byte[] stegoAudio)
        {
            double mse = 0.0;
            for (int i = 0; i < originalAudio.Length; i++)
            {
                double diff = originalAudio[i] - stegoAudio[i];
                mse += diff * diff;
            }
            return mse / originalAudio.Length;
        }

        private async void audioClassify_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt the user to input text size
                //string inputTextSize = Microsoft.VisualBasic.Interaction.InputBox("Enter the text size in bits:", "Input Text Size", "0");
                //if (string.IsNullOrEmpty(inputTextSize) || !double.TryParse(inputTextSize, out double textSize))
                //{
                //    MessageBox.Show("Invalid text size entered. Please enter a valid number.");
                //    return;
                //}
                string textSizeString = textSize.ToString();
                MessageBox.Show("Text size: " + textSizeString);


                // Disable the button and update the text to indicate processing
                audioClassify_button.Enabled = false;
                audioClassify_button.Text = "Classifying...";

                // Instantiate the AudioClassifier class and call the prediction function
                AudioClassifier audioClassifier = new AudioClassifier();
                string prediction = await audioClassifier.GetAudioPredictionAsync(textSize, embeddingCapacity, bps, snr, mse);

                // Display the prediction result in a message box
                MessageBox.Show($"The model classifies the audio stego as: {prediction}");
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the process
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Reset the button once classification is complete
                audioClassify_button.Text = "Classify Audio";
                audioClassify_button.Enabled = true;
            }
        }

    }
}
