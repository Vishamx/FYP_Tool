using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace FYP_Tool
{
    class AES
    {


        public AES()
        {
            //
        }
        public static byte[] encrypt(string plaintext, byte[] secret_key, byte[] iv)
        {
            byte[] ciphertext;

            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(secret_key, iv);
                using (MemoryStream memoryStreamEncrypt = new MemoryStream())
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStreamEncrypt))
                        {
                            streamWriter.Write(plaintext);
                        }

                        ciphertext = memoryStreamEncrypt.ToArray();

                    }
                }
            }

            return ciphertext;

        }

        public static string decrypt(byte[] ciphertext, byte[] secret_key, byte[] iv)
        {

            string plaintext = " ";
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(secret_key, iv);
                using (MemoryStream memoryStreamDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream cryptoStreamDecrypt = new CryptoStream(memoryStreamDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStreamDecrypt))
                        {
                            plaintext = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}