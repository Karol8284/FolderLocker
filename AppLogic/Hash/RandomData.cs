using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderLocker.AppLogic.Hash
{
    internal class RandomData
    {
        public RandomData( ) { }
        public string ReturnString(int size) {
            Random random = new();
            string stringChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] chars = new char[stringChars.Length];
            for (int i = 0; i < size; i++)
            {
                chars[i] = stringChars[random.Next(stringChars.Length)];
            }
            return new String(chars);

        }
        //public RandomData() { }
    }
}
