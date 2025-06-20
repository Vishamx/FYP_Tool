using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_Tool
{
    public partial class EncryptionForm : Form
    {
        public static string encryptedText;
        private byte[] secret_key;
        private byte[] iv; //laisse as members so decryption fucntion easier than to read from file and load.

        private string KeyFilePath = "C:\\Users\\rohan\\Desktop\\resultStegoImgsecret_key_iv.txt";

        public EncryptionForm()
        {
            InitializeComponent();
        }

        public void SetOriginalText(string data)
        {
            dataToEncrypt_rtb.Text = data;
            dataToEncrypt_rtb.Enabled = true;
        }

        private void applyEncryption_button_Click(object sender, EventArgs e)
        {
            string text = dataToEncrypt_rtb.Text;

            secret_key = new byte[16];
            iv = new byte[16];

            using (RandomNumberGenerator randomNum = RandomNumberGenerator.Create())
            {
                randomNum.GetBytes(secret_key);
                randomNum.GetBytes(iv);
            }

            SaveSecretKeyAndIV(KeyFilePath, secret_key, iv);

            string secretKeyString = BitConverter.ToString(secret_key);
           // MessageBox.Show(secretKeyString);

            // Start the stopwatch
            //Stopwatch stopwatch = Stopwatch.StartNew();

            // Perform the encryption
            byte[] Encrypted_bytes = AES.encrypt(text, secret_key, iv);

            // Stop the stopwatch
           // stopwatch.Stop();

            // Display the encryption time in milliseconds
           // double encryptionTimeInMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
            //MessageBox.Show($"Encryption time: {encryptionTimeInMilliseconds} ms");


            encryptedText = Convert.ToBase64String(Encrypted_bytes);
            encryptedData_rtb.Text = encryptedText;
        }

        private void applyDecryption_button_Click(object sender, EventArgs e)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData_rtb.Text);
            string decryptedText = AES.decrypt(encryptedBytes, secret_key, iv);

            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(decryptedText))
            {
                viewer.ShowDialog();
            }
            
        }

        private void showFullEncryptedData_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(encryptedData_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

        public static void SaveSecretKeyAndIV(string filePath, byte[] secretKey, byte[] iv)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(Convert.ToBase64String(secretKey));
                writer.WriteLine(Convert.ToBase64String(iv));
            }
        }

        public static void LoadSecretKeyAndIV(string filePath, out byte[] secretKey, out byte[] iv)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                secretKey = Convert.FromBase64String(reader.ReadLine());
                iv = Convert.FromBase64String(reader.ReadLine());
            }
        }

        private void showFullMsg_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(dataToEncrypt_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }

    }
}