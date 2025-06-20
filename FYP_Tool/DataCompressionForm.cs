using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_Tool
{
    public partial class DataCompressionForm : Form
    {

        private Compression.HuffmanNode root; // Store the root node of the Huffman tree
        public static string compressedText;
        private string HuffmanFilePath = "C:\\Users\\rohan\\Desktop\\huffman_root_node.json";

        private const int WarningThreshold = 2000000000; // 2 billion characters

        public DataCompressionForm()
        {
            InitializeComponent();
        }

        public void SetEncryptedMessage(string Message)
        {
            normalText_rtb.Text = Message;

        }

        private void calcSizeOgText_button_Click(object sender, EventArgs e)
        {
            string text = normalText_rtb.Text;

            // Calculate the size of the text in bytes
            int sizeInBytes = Encoding.UTF8.GetByteCount(text);
            int sizeInBits = sizeInBytes * 8;

            // Convert bytes to kilobytes
            double sizeInKB = Math.Round(sizeInBytes / 1024.0, 1);

            ImageSteganographyForm.settextSize(sizeInBits);
            AudioSteganographyForm.setAudioTextSize(sizeInBits);

            MessageBox.Show("Size of message before compression: " + sizeInBytes + " bytes or " + sizeInBits + " bits or " + sizeInKB + " KB ", "Size of text");
        }

        private void applyCompression_button_Click(object sender, EventArgs e)
        {

            string textToCompress = normalText_rtb.Text;

            compressedText = Compression.Compress(textToCompress);

            if (compressedText.Length > WarningThreshold)
            {
                MessageBox.Show("Max capacity of this text box is reached, which will result in data loss. The compressed text will be saved to a file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Prompt the user to save the file
                SaveCompressedTxT(compressedText);
                return;
            }
            else
            {
                compressed_rtb.Text = compressedText;
            }

            root = Compression.GetRootNode();// here root is saved in a variable as SENDER also can use decompression for tests purposes in the same form
            SaveHuffmanRootNode(HuffmanFilePath, root);  //save root node in JSON file to be sent to recipient
        }



        private void calcSizeCompText_button_Click(object sender, EventArgs e)
        {
            string compressedData = compressed_rtb.Text;

            // Count the number of characters in the compressed data
            int numberOfBits = compressedData.Length;

            // Calculate the size of the compressed data in bytes
            int sizeInBytes = (int)Math.Ceiling((double)numberOfBits / 8); // Divide by 8 to convert bits to bytes

            // Convert bytes to kilobytes
            double sizeInKB = Math.Round(sizeInBytes / 1024.0, 1);

            ImageSteganographyForm.settextSize(numberOfBits);
            AudioSteganographyForm.setAudioTextSize(numberOfBits);

            MessageBox.Show("Size of message after compression: " + sizeInBytes + " bytes or " + numberOfBits + " bits or " + sizeInKB + " KB ", "Size of text");
        }

        private void applyDecompression_button_Click(object sender, EventArgs e)
        {
            if (root == null)
            {
                MessageBox.Show("Please compress the data first.", "Error");
                return;
            }

            string compressedData = compressed_rtb.Text;

            string decompressedData = Compression.Decompress(compressedData, root); // Pass the root node for decompression


            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(decompressedData))
            {
                viewer.ShowDialog();
            }
        }

        private void showFullCompressedText_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(compressed_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        public static void SaveHuffmanRootNode(string filePath, Compression.HuffmanNode root)
        {
            string jsonString = JsonSerializer.Serialize(root);
            File.WriteAllText(filePath, jsonString);
        }

        public static Compression.HuffmanNode LoadHuffmanRootNode(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Compression.HuffmanNode>(jsonString);
        }

        private void SaveCompressedTxT(string compressedText)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Compressed Text";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, compressedText);
                    MessageBox.Show("Compressed text has been saved to: " + saveFileDialog.FileName, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void showFullNormalText_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(normalText_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }
    }
}
