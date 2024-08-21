using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderLocker.AppLogic.User
{
    internal class KeysFilePattern
    {
        public string name;
        public string login;
        public string password;
        public byte[] key;
        public byte[] iv;

        // name login passwrod key iv
        public KeysFilePattern(string name,string login,string password, byte[] key, byte[] iv) 
        { 
            this.name = name;
            this.login = login;
            this.password = password;
            this.key = key;
            this.iv = iv;
        }
        public string returnKeysFileDataAsJson()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}
