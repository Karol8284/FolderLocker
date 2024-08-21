using FolderLocker.AppLogic.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FolderLocker.AppLogic.User;
using FolderLock.Pages;

namespace FolderLocker.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
            //Register register = new("login", "password");
        }

        private void Go_Back_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoginPage();
            this.Close();
            window.Show();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string repeatPassword = RepeatPasswordTextBox.Text;

            if (login == "" || password == "" || repeatPassword == "")
            {
                MessageBox.Show("Error value == null");
            }
            else
            {
                if (password == repeatPassword)
                {
                    Register register = new();
                    User user = register.Start(login, password);
                    /*
                    var homePageWindow = new HomePage();
                    this.Close();
                    homePageWindow.Show();
                */
                    var window = new WindowToSelectFiles(user);
                    this.Close();
                    window.Show();
                }

            }
        }
    }
}
