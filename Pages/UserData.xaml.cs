using FolderLocker.AppLogic.User;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace FolderLock.Pages
{

    // Create buttons to changing user data and use User.ChangData method

    /// <summary>
    /// Logika interakcji dla klasy UserData.xaml
    /// </summary>
    public partial class UserData : Window
    {
        public User _User { get; set; }
        private string Id { get; set; }
        private string Name { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        public string _Id { get => Id; set => Id=value; }
        public string _Name { get => Name; set => Name = value; }
        public string _Login { get => Login; set => Login = value; }
        public string _Password { get => Password; set => Password = value; }

        string aaa = "aaaaa";


        public UserData()
        {
            InitializeComponent();
        }
        public UserData(User user)
        {
            //MessageBox.Show(user.Name);
            _User = user;
            Id = user.ID;
            Login = user.Login;
            Name = user.Name;
            Password = user.Password;
            this.DataContext = _User;

            //MessageBox.Show(_User.Name);
            InitializeComponent();
        }

        private void ChengeName_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ChengeLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ChengePassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
