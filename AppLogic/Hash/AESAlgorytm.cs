using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;

namespace FolderLocker.AppLogic.Hash
{
    // Algorytm to long string
    internal class AESAlgorytm
    {
        Aes aes;
        byte[] data;
        byte[] key;
        byte[] iv;
        public AESAlgorytm()
        {
            this.aes = Aes.Create();
            this.key = aes.Key;
            this.iv = aes.IV;
        }
        public Aes returnAES()
        {
            return this.aes;
        }
        public byte[] returnAESKey()
        {
            return key;
        }
        public byte[] returnAESIv()
        {
            return this.iv;
        }
        public AESAlgorytm(byte[] key, byte[] iv)
        {
            this.aes = Aes.Create();
            this.aes.Key = key;
            this.aes.IV = iv;
        }
        public byte[] Encrypt(string textToHash, byte[] key, byte[] iv)
        {
            if (textToHash == null || textToHash.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encryptedTab;
            string encryptedString = "";
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new())
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                        {
                            streamWriterEncrypt.Write(textToHash);
                        }
                        encryptedTab = memoryStream.ToArray();
                    }
                }
            }
            return encryptedTab;
        }
        public string Decrypt(byte[] dataToHash, byte[] key, byte[] iv)
        {
            if (dataToHash == null || dataToHash.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            //byte[] dataToDecrypt = Convert.FromBase64String(dataToHash);
            string decryptedString = "";
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new(dataToHash))
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReaderDecrypt = new StreamReader(cryptoStreamEncrypt))
                        {
                            decryptedString = streamReaderDecrypt.ReadLine();
                        }
                    }
                }
            }

            return decryptedString;
        }
        public string TryDecrypt(byte[] dataToHash, byte[] key, byte[] iv)
        {
            try
            {
                return Decrypt(dataToHash, key, iv);
            }
            catch { return null; }
        }
    }
}