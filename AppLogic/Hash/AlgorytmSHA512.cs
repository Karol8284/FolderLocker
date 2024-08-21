using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLock.AppLogic.Hash
{
    internal class AlgorytmSHA512
    {
        private byte[] resultByte { get; set; }
        private byte[] resultString { get; set; }
        public AlgorytmSHA512() { }
        public AlgorytmSHA512(byte[] data)
        {

        }
        /// <summary>
        /// Hash string to byte Hashed
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Hash(string data)
        {
            if (data == null) return null;
            byte[] tab = Encoding.UTF8.GetBytes(data);

            using(SHA512 sha512 = SHA512.Create())
            {
                resultString = sha512.ComputeHash(tab);
            }
            if (resultString == null) return null;
            return Convert.ToBase64String(resultString);
        }

    }
}
