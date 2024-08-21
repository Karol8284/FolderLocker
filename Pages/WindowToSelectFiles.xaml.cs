using FolderLock.AppLogic.Hash;
using FolderLocker.AppLogic.User;
using FolderLocker.Data.AppVariables;
using FolderLocker.Pages;
using System.Windows;

namespace FolderLock.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy WindowToSelectFiles.xaml
    /// </summary>
    public partial class WindowToSelectFiles : Window
    {
        Dictionary<string, Dictionary<string, byte[]>> FolderDictonary;
        User User;
        private User _User 
        {
            get
            {
                if(User != null) return User;
                return null;
            } 
            set => User = value;
        }
        public WindowToSelectFiles()
        {
            this.User = new User();
            InitializeComponent();
        }
        public WindowToSelectFiles(User user)
        {
            this.User = user;
            MessageBox.Show(User.Name);
            InitializeComponent();
        }
        /// <summary>
        /// Open window with user data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new UserData(User);
            Application.Current.MainWindow.Show();
        }
        /// <summary>
        /// Logout from app to login page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new LoginPage();
            Application.Current.MainWindow.Show();
            this.Close();
        }
        /// <summary>
        /// select Path and open window for select type of Hashing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hash_Click(object sender, RoutedEventArgs e)
        {
            string pathToFolder = TextBox_PathToSearch.Text;
            if (pathToFolder == null || pathToFolder == "" || pathToFolder == "C:\\")
            {
                TextBox_PathToSearch.Text = "C:\\";
                MessageBox.Show("ERROR Null OR C:\\ TextBox_PathToSearch");
            }
            else
            {
                HashData hashData = new();
                Dictionary<string, Dictionary<string, byte[]>> PathsHandler = hashData.Hash(pathToFolder, "");
                User.SetDataToKeysTab(PathsHandler);
                User.SaveUserToFile();
                // MessageBox.Show("userJson: " + JsonConvert.DeserializeObject<User>(userJson));
                MessageBox.Show("WindowToSelectFiles - User: " + User.ReturnJsonData);

            }
        }
        /// <summary>
        /// Selected Path for file to Dehashing and open window for set all data nidet to deHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeHash_Click(object sender, RoutedEventArgs e)
        {
            string pathToFolder = TextBox_PathToSearch.Text;
            if (pathToFolder == null || pathToFolder == "" || pathToFolder == "C:\\")
            {
                TextBox_PathToSearch.Text = "C:\\";
                MessageBox.Show("ERROR Null OR C:\\ TextBox_PathToSearch");
            }
            else
            {
                DeHashData deHashData = new();
                Dictionary<string, Dictionary<string, byte[]>> PathsHandler = deHashData.DeHash(User,pathToFolder);
                User.SetDataToKeysTab(PathsHandler);
                User.SaveUserToFile();
                // MessageBox.Show("userJson: " + JsonConvert.DeserializeObject<User>(userJson));
                MessageBox.Show("WindowToSelectFiles - User: " + User.ReturnJsonData);

            }
        }
    }
}
