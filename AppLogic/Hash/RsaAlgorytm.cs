    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    namespace FolderLocker.AppLogic.Hash
    {

        internal class RsaAlgorytm
        {
     
            public RsaAlgorytm(){       }
        /*
            public RSACryptoServiceProvider returnRSA() {
                //rsa = new RSACryptoServiceProvider();
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);
                MessageBox.Show($"" + publicKey + " \n" + privateKey);
            
                return rsa;
            }
        */  
        /*

        public RSACryptoServiceProvider GenerateRSA(string containerName, string value)
        {
            cspParameters = new CspParameters();
            //rsa = new RSACryptoServiceProvider(cspParameters);

            using (rsa = new RSACryptoServiceProvider(cspParameters))
            {

                byte[] data = rsa.Encrypt(Encoding.UTF8.GetBytes(dataToSave), true);
                return Convert.ToBase64String(data);
            }
            return rsa;
        }
        */
        public string[] Encrypt(string dataToSave)
        {
            string[] res = new string[3]; 
            CspParameters cspParameters = new CspParameters();
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters))
            {
                try
                {
                    MessageBox.Show("dataToSave: " + dataToSave);
                    byte[] data = rsa.Encrypt(Encoding.UTF8.GetBytes(dataToSave), true);
                    res[0] = Convert.ToBase64String(data);
                    res[1] = rsa.ToXmlString(true);
                    res[2] = rsa.ToXmlString(false);
                    MessageBox.Show("dataToSave: " + dataToSave);
                    return res;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return res;
        }
        public string[] Decrypt(string dataToEncrypt)
        {
            CspParameters cspParameters = new CspParameters();
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters))
            {
                byte[] data = Convert.FromBase64String(dataToEncrypt);
                byte[] decryptedData = rsa.Decrypt(data, true); //or true
            string[] res = { Encoding.UTF8.GetString(decryptedData),rsa.ToXmlString(true), rsa.ToXmlString(false) };
                return res;
            }
        }
        public string Decrypt(string dataToEncrypt, string key)
        {
            CspParameters cspParameters = new CspParameters();
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters))
            {
                byte[] data = Convert.FromBase64String(dataToEncrypt);
                rsa.FromXmlString(key);
                try
                {
                    byte[] decryptedData = rsa.Decrypt(data, true);
                return Encoding.UTF8.GetString(decryptedData);
                }catch (Exception ex) { Console.WriteLine(ex.Message); }
                return "";
            }
        }
    }
}
