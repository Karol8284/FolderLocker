using FolderLock.Pages;
using FolderLocker.AppLogic.User;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace FolderLocker.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {

        public LoginPage()
        {

            LoginForm loginForm = new()
            {
                Login = "Login: ",
                Password = "Password: "
            };
            this.DataContext = loginForm;
            InitializeComponent();  
        }

        class LoginForm
        {
            public LoginForm()
            {
                Login = "";
                Password = "";
            }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = FormLoginTextBox.Text;
            string password = FormPasswordTextBox.Text;
            
            if(login == null || login == "" || password == null || password == "")
            {
                MessageBox.Show($"Error pogin or passwrod == null ");
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path = Directory.GetParent(path).Parent.Parent.Parent.FullName;
                Login loginClass = new Login(login, password);
                User user = loginClass.GetUserFromDatabase(login, password);

                if (user == null)
                {
                    FormLoginTextBox.Text = "";
                    FormPasswordTextBox.Text = "";
                }
                else
                {
                    //path = Path.Combine(path,"Data","UsersData", user.name);
                    //var window = new HomePage(user,path);
                    var window = new WindowToSelectFiles(user);
                    Application.Current.MainWindow = window;
                    window.Show();
                    this.Close();
                }
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterPage();
            this.Close();
            window.Show();
        }
        private void Recovery_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Recovery Account");
        }
    }
}