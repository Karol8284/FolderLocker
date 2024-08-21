using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLocker.AppLogic.Hash
{
    internal class AppHash
    {
        byte[] byteHashTab;
        StringBuilder stringBuilder = new StringBuilder();
        public bool checkStringAndByteTab(String normalText, byte[] byteTab, string typeEncode)
        {
            switch ( typeEncode)
            {
                case "sha512":
                    SHA512 sha512 = SHA512.Create();
                    byteHashTab = sha512.ComputeHash(Encoding.UTF8.GetBytes(normalText));
                    for (int i = 0; i < byteHashTab.Length; i++)
                    {
                        stringBuilder.Append(byteHashTab[i].ToString("x2"));   
                    }
                    string inputStr = stringBuilder.ToString();

                    for (int i = 0; i < byteTab.Length; i++)
                    {
                        stringBuilder.Append(byteHashTab[i].ToString("x2"));
                    }
                    string hashedStr = stringBuilder.ToString();
                    if (inputStr == hashedStr)
                    {
                        Console.WriteLine(inputStr + " " + hashedStr);
                    } 
                break;

            }
            return true;
        }
        public bool checkStringAndHashedString(String text, String hashedText)
        {


            return true;
        }
    }
}
