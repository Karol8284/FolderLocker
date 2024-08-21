using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.Hash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLocker.AppLogic.User
{
    internal class Login
    {
        public Login(string login, string password)
        {
            //IsDataInDatabase(login,password);

        }
        private KeysFilePattern DataFromDatabase(string login,string password)
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Directory.GetParent(path).Parent.Parent.Parent.FullName;
            path = Path.Combine(path, "Data");
            string KeysFilePath = Path.Combine(path,"Security","Keys.txt");

            string[] allDataFromKeysFile = File.ReadAllLines(KeysFilePath);
            foreach(string data in  allDataFromKeysFile)
            {
                // 0 User : 1 :login : 2 password : 3 key 4 iv  
                try
                {
                    KeysFilePattern keysFilePattern = JsonConvert.DeserializeObject<KeysFilePattern>(data);
                    if (keysFilePattern == null)
                    {
                        return null;                    
                    }
                    if (login == keysFilePattern.login && password == keysFilePattern.password) 
                    {
                        return keysFilePattern;    
                    }
                }catch(Exception ex) { MessageBox.Show(ex.Message); }

            }
            return null;
        }
        public User GetUserFromDatabase(string login, string password)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Directory.GetParent(path).Parent.Parent.Parent.FullName;

            KeysFilePattern keysFilePattern = DataFromDatabase(login, password);
            if (keysFilePattern == null) return null;
            
            string userFilePath = Path.Combine(path,"Data", "UsersData", keysFilePattern.name,"User.txt");

            FileEdit fileEdit = new();
            //byte[] dataBeforeDecode = Encoding.UTF8.GetBytes(fileEdit.Read(userFilePath));
            
            // String from file to byte[]
            byte[] dataBeforeDecode = Convert.FromBase64String(fileEdit.Read(userFilePath));
            
            AESAlgorytm aes = new AESAlgorytm();
            string dataAftenDecode = aes.Decrypt(dataBeforeDecode,keysFilePattern.key,keysFilePattern.iv);
            //User user = JsonConvert.DeserializeObject<User>(dataAftenDecode);
            try
            {
                //MessageBox.Show("userJson: " + JsonConvert.DeserializeObject<User>(dataAftenDecode));
                MessageBox.Show(" Login - userJson: " + dataAftenDecode);
                User user = JsonConvert.DeserializeObject<User>(dataAftenDecode);
                MessageBox.Show(" Login - userJson: " + JsonConvert.DeserializeObject<User>(dataAftenDecode));
                if (user == null) return null;
                return user;

            }catch (Exception ex)
            {
                MessageBox.Show($"ex: " + ex);
            }


            return null;
        }
    }
}
