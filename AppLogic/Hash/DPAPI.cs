using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLocker.AppLogic.Hash
{
    internal class DPAPI
    {
        DataProtectionScope scope;
        byte[] encryptedData;
        byte[] decryptedData;

        public DPAPI() 
        {
            this.scope = DataProtectionScope.LocalMachine;
        }

        // szyfracja danych
        public string Encrypt(string stringToEncrypt,string entropy)
        {
            encryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(stringToEncrypt),
               entropy != null ? Encoding.UTF8.GetBytes(entropy) : null , scope);

            Console.WriteLine("encryptedData: " + encryptedData);

            return Convert.ToBase64String(encryptedData);
        }
        // deszyfracja danych
        public string Decrypt(string stringToDecrypt, string entropy)
        {
            decryptedData = ProtectedData.Unprotect(
                Convert.FromBase64String(stringToDecrypt),
                entropy != null ? Encoding.UTF8.GetBytes(entropy) : null, scope);
            Console.WriteLine("stringToDecrypt: " + stringToDecrypt);
            Console.WriteLine("decryptedData: " + decryptedData);


            return Convert.ToBase64String(decryptedData);
            //return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
