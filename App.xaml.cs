using FolderLock.AppLogic.Hash;
using FolderLock.Pages;
using FolderLocker.AppLogic.Hash;
using FolderLocker.AppLogic.User;
using FolderLocker.Data.AppVariables;
using FolderLocker.Pages;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;

namespace FolderLock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //   StartupUri="Pages/LoginPage.xaml">
        public App()
        {
            /*
            ResultLineDataFromFile r = new ResultLineDataFromFile("a","aaa", @"C:\rtr8F24.tmp",10);
            MessageBox.Show("$: "+r);
            MessageBox.Show("-$$$- "+r.Label_FileName + "");
            */
            //MessageBox.Show("aaaaaaaaaaaaaaaa");
            GlobalAppVariables globalAppVariables = new();


            //Application.Current.MainWindow = new WindowFilesExplorel();
            //Application.Current.MainWindow.Show();


            //MessageBox.Show(globalAppVariables.AppMainDirectory);
            //MessageBox.Show(globalAppVariables.AppMainIconsFolderDirectory);

            //Test

            //FilesTypes f = new();
            //string path = @"D:\a1.txt";
            //string path = @"C:\Users\mckar\OneDrive\Obrazy\Zrzuty ekranu\Zrzut ekranu (175).png";
            //string path1 = f.ReturnPathToIcons(path);
            //MessageBox.Show("path1: " + Directory.GetFiles(path1));

            //string path = @"C:\Users\mckar\OneDrive\Obrazy\Zrzuty ekranu\Zrzut ekranu (175).png";

            /*

            DPAPI d = new DPAPI();
            string s = d.Encrypt("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","aaa");
            MessageBox.Show(s);
            string r = d.Decrypt(s, "aaa");
            MessageBox.Show(r);

            */
            //HashData hashData = new HashData("C:\\","");

            //End Test
            //Start aplication

            Application.Current.MainWindow = new LoginPage();
            Application.Current.MainWindow.Show();

            

            //Application.Current.MainWindow = new WindowToSelectFiles();
            //Application.Current.MainWindow.Show();

        }
    }

}
