using System.Security.Cryptography;
using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.Hash;
using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace FolderLocker.AppLogic.User
{
    internal class Register
    {
        public Register() { }
        public User Start(string login, string password)
        {
            RsaAlgorytm rsa = new();
            RandomData randomData = new();
            string userPath = AppDomain.CurrentDomain.BaseDirectory;
            userPath = Directory.GetParent(userPath).Parent.Parent.Parent.FullName;
            string pathToKeys = Path.Combine(userPath, "Data", "Security", "Keys.txt");

            userPath = Path.Combine(userPath, "Data", "UsersData");
            FileEdit fileEdit = new();

            userPath = fileEdit.CreateFolder(userPath, "User");
            DirectoryInfo directoryInfo = new DirectoryInfo(userPath);

            string userId = randomData.ReturnString(50);
            string userName = directoryInfo.Name;
            string userLogin = login;
            string userPassword = password;

            // inicialization aes 
            AESAlgorytm aESAlgorytm = new AESAlgorytm();
            Aes aes = aESAlgorytm.returnAES();

            MessageBox.Show("userJson: " + aes.Key);
            User newUser = new(userId ,userName,userLogin,password,aes.Key,aes.IV);

            string userJson = JsonConvert.SerializeObject(newUser);
            MessageBox.Show("userJson: " + userJson);
            MessageBox.Show("userJson: " + JsonConvert.DeserializeObject(userJson));
            MessageBox.Show("userJson: " + JsonConvert.DeserializeObject<User>(userJson));

            byte[] userAes = aESAlgorytm.Encrypt(userJson, aes.Key, aes.IV);


            //Napisać hash i zapisuwanie do pliku user oraz keys

            KeysFilePattern keysFilePattern = new(userName,userLogin,userPassword,aes.Key,aes.IV);
            
            //Write Encrypt do user in user class return to save
            string userFilePath = fileEdit.CreateFile(userPath, "User.txt", false);
            fileEdit.Write(userFilePath, Convert.ToBase64String(userAes), false);
            fileEdit.Write(pathToKeys,keysFilePattern.returnKeysFileDataAsJson() + "\n" , true);

            //Directory.CreateDirectory(Path.Combine(userFilePath, "Data"));

            MessageBox.Show($"dataToUserFile: " + Convert.ToBase64String(userAes));
            MessageBox.Show($"keysFilePattern: " + keysFilePattern.returnKeysFileDataAsJson());

            return newUser;
            // Zapis danych do Keys 
            // 0 User : 1 :login : 2 password : 3 keys
        }
    }
        
}
// register -> generate keys -> save user to Keys.txt { u1 ,u1,u1 }