using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.Hash;
using FolderLocker.Data.AppVariables;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace FolderLocker.AppLogic.User
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public byte[] Key { get; set; }
        public byte[] Iv { get; set; }

        public Dictionary<string, Dictionary<string, byte[]>> KeysTab { get; set; }
        public User() { }
        public User(string ID, string name, string login, string password)
        {
            this.ID = ID;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.KeysTab = new();
        }
        public User(string ID, string name, string login, string password, byte[] key, byte[] iv)
        {
            this.ID = ID;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.KeysTab = new();
            this.Key = key;
            this.Iv = iv;
        }
        public User(string ID, string name, string login, string password, Dictionary<string, Dictionary<string, byte[]>>  keysTab)
        {
            this.ID = ID;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.KeysTab = keysTab;
        }
        public User(string jsonString)
        {
            /*
            this.ID = ID;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.KeysTab = keysTab;
            */
        }
        GlobalAppVariables AppVariables = new();
        public string ReturnStringDataToKeysFile()
        {
            return this.Name + " : " + this.Login + " : " + this.Password;
        }
        public string ReturnStringDataToUserFile()
        {
            //return this.name + " : " + this.login +" : "+ this.password+ " : " + this.keysTab;
            return this.Name + " : " + this.Login + " : " + this.Password;

        }
        public string ReturnJsonData()
        {
            return JsonConvert.SerializeObject(this);
        }
       
        public string Decrypt(string data,string privateKey)
        {
            RsaAlgorytm rsa = new();
            return rsa.Decrypt(data, privateKey);
        }
        /// <summary>
        /// Set files sahses of folders to KeysTab
        /// </summary>
        /// <param name="dataToSet"></param>
        /// <returns></returns>
        public bool SetDataToKeysTab(Dictionary<string, Dictionary<string, byte[]>> dataToSet)
        {
            if (dataToSet.Count <= 0) return false;
            foreach (var item in dataToSet)
            {
                //MessageBox.Show(item+"");
                KeysTab.TryAdd(item.Key,item.Value);
            }
            return true;
        }
        public string GetPathToUserFolder(string data, string privateKey)
        {
            GlobalAppVariables appVariables = new();
            return Path.Combine(appVariables.AppMainUsersFolderPath, Name);
        }
        public bool ChangeDataInUserFile()
        {
            // code to  save chang in user to user file
            return true;
        }
        public string ReturnPathUserFolder()
        {
            GlobalAppVariables appVariables = new();
            return Path.Combine(appVariables.AppMainUsersFolderPath,Name);
        }
        public string ReturnPathUserFile()
        {
            GlobalAppVariables appVariables = new();
            return Path.Combine(appVariables.AppMainUsersFolderPath,Name,"User.txt");
        }

        public bool ChangeUserData(UserEnums userElement, string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            // Napisać algoryt 
            AESAlgorytm aes = new();
            switch(userElement){
                case UserEnums.KeysTab:
                    {

                    }
                    break;
            }

            return false;
        }
        public User GetUserFromFile()
        {
            FileEdit fileEdit = new();
            string strResult = fileEdit.Read(Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "User.txt"));
            AESAlgorytm aes = new();
            byte[] dataBeforeDecode = Convert.FromBase64String(fileEdit.Read(strResult));
            aes.Decrypt(dataBeforeDecode, Key, Iv);
            if (JsonConvert.DeserializeObject<User>(strResult) != null) return JsonConvert.DeserializeObject<User>(strResult);
            return null;
        }
        public bool SaveUserToFile()
        {
            
            MessageBox.Show("SaveUserToFile ");
            MessageBox.Show("User - JsonConvert.SerializeObject: "+JsonConvert.SerializeObject(this));
            MessageBox.Show("SaveUserToFile PAth = path: \n"+ (Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "User.txt")+ "\n"+ @"C:\Users\mckar\source\repos\Moje Prywatne\FolderLocker\FolderLock\Data\UsersData\User0\User.txt") );
            MessageBox.Show("SaveUserToFile Path: "+ Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "UserData.txt"));
            AESAlgorytm aes = new();
            byte[] UserEncrypt = aes.Encrypt(JsonConvert.SerializeObject(this), this.Key, this.Iv);

            ChangeDataInDataBase();

            FileEdit fileEdit = new();
            fileEdit.Write(Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "User.txt"), Convert.ToBase64String(UserEncrypt), false);
            fileEdit.Write(Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "UserData.txt"), JsonConvert.SerializeObject(this), false);
            return true;
            /*
            try
            {
            AESAlgorytm aes = new();
            byte[] UserEncrypt = aes.Encrypt(JsonConvert.SerializeObject(this), Key,Iv);
            FileEdit fileEdit = new();
            fileEdit.Write(Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "User.txt"), Convert.ToBase64String(UserEncrypt), false);
            fileEdit.Write(Path.Combine(AppVariables.AppMainUsersFolderPath, Name, "UserData.txt"), JsonConvert.SerializeObject(this), false);
            return true;
            }
            catch(Exception ex) {
                MessageBox.Show("User - SaveUserToFile: " + ex); return false; 
            }
            */
        }

        /// <summary>
        /// This is the Method that will be changing User data in user main file. After login data needed to login or user data will be diffrent.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool ChangeDataInFile(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;


            // Napisać algoryt 
            return false;
        }
        public bool Delete()
        {
            //Delete USer from all plases 
            return false;
        }
        public enum UserEnums
        {
            Id,
            Name,
            Login,
            Password,
            Key,
            Iv,
            KeysTab
        }

        private bool ChangeDataInDataBase()
        {
            //AppVariables.AppMainSecurityFolderPath;
            return false;
        }

    }
   
}
/*
 * byte[] data, byte[] key, byte[] iv => file [Dictionary<string, byte[]>]
 * file [Dictionary<string, byte[]>] => Folder [Dictionary<string, Dictionary]
 * Folder [Dictionary<string, Dictionary] => User {Object] 
 *  
 * User.KeysTab => Dictionary<string, Dictionary<string, byte[]>>)
 * User.KeysTab => Dictionary<Folder, Dictionary<File, byte[]>>)
 * 
 */