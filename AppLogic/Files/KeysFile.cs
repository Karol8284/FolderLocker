using Newtonsoft.Json;
using System.Windows;

namespace FolderLocker.AppLogic.Files
{
    internal class KeysFile
    {
        public string userName { get; set; }
        public string login { get; set; }
        public string passwrod { get; set; }
        public string data { get; set; }
        public KeysFile() { }
        public string ReturnData(string userName, string login, string password, string data) 
        { 
            this.userName = userName;
            this.login = login;
            this.passwrod = password;
            this.data = data;
            MessageBox.Show($"" +this.userName +" " + this.login);
            MessageBox.Show($"JsonConvert " + JsonConvert.SerializeObject(this));

            return JsonConvert.SerializeObject(this);
        }
    }
}
