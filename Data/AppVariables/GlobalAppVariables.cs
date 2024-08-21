using FolderLock.Data.AppVariables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLocker.Data.AppVariables
{
    internal class GlobalAppVariables
    {
        /*

        public string AppDirectoryOperations = System.AppContext.BaseDirectory;
        public string AppDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; 
        public string AppMainIconsFolderDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DataToAplication");
        public string AppMainIconNotFoundPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DataToAplication", "error-404.png");
        public string AppmainUsersFolder{ get; set; }
        */
        public string AppDirectory { get; set; }
        public string AppMainIconsFolderDirectory { get; set; }
        public string AppMainIconNotFoundPath{ get; set; }
        public string AppMainUsersFolderPath{ get; set; }
        public string AppMainSecurityFolderPath{ get; set; }
        public UserData User = new();
        // iconsFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public GlobalAppVariables()
        {
            AppDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            AppMainIconsFolderDirectory = Path.Combine(AppDirectory, "DataToAplication");
            AppMainIconNotFoundPath = Path.Combine(AppMainIconsFolderDirectory, "error-404.png");
            AppMainUsersFolderPath = Path.Combine(AppDirectory, "Data", "UsersData");
            AppMainSecurityFolderPath = Path.Combine(AppDirectory, "Data", "Security");
            //MessageBox.Show(AppDirectory);
            //MessageBox.Show("SaveUserToFile PAth = path: \n"+ (Path.Combine(AppMainUsersFolderPath, "User0", "User.txt")+ "\n"+ @"C:\Users\mckar\source\repos\Moje Prywatne\FolderLocker\FolderLock\Data\UsersData\User0\User.txt") );


        }
    }
}
/*
 * string userJson = JsonConvert.SerializeObject(newUser);
            MessageBox.Show("userJson: " + userJson);
            MessageBox.Show("userJson: " + JsonConvert.DeserializeObject(userJson));
            MessageBox.Show("userJson: " + JsonConvert.DeserializeObject<User>(userJson));
*/