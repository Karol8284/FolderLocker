using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;

namespace FolderLocker.AppLogic.Hash
{
    internal class Encrypt
    {
        //byte[] encryptedByteTab;
        byte[] key;
        byte[] iv;

        public Encrypt() { }
        public string[] Encrtypion(string inputStr,string entropy)
        {
            //!= null ? Encoding.UTF8.GetBytes(entropy) : null
            using (Aes aes = Aes.Create())
            {
                //this.key = Encoding.UTF8.GetBytes(inputStr);
                //this.iv = Encoding.UTF8.GetBytes(entropy);

                ICryptoTransform encryptor = aes.CreateEncryptor(key,iv);
                aes.GenerateKey();
                aes.GenerateIV();
                key = aes.Key;
                iv= aes.IV;
                MessageBox.Show($"" + key +" \n"+iv);
                string[] tab = { Convert.ToBase64String(key), Convert.ToBase64String(iv) };
                return tab;
                /*
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                        null, CryptoStreamMode.Write)) ;
                }
             //   encryptedByteTab = aes.CreateEncryptor(inputStr, key, iv);
                */
            }
        }
        /*
        public void Encrtypion()
        {

        }
        */
    }
}
