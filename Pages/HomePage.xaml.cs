using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.User;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FolderLocker.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        String userPath;
        String userPathToData;
        User user { get; set; }
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(User user,string path)
        {
            this.user = user;
            this.userPath = path;
            //MessageBox.Show(user.name);
            userPathToData = Path.Combine(path, "Data");
            MessageBox.Show("userPathToData: "+ userPathToData);
            InitializeComponent();
            SetFilesAndDataToPage(userPathToData);
        }

        protected void setButtonsToPage()
        {

        }
        protected void SetFilesAndDataToPage(string path)
        {
            try
            {
                FileEdit fileEdit = new();
                //FileInfo[] fileInfos = fileEdit.ReturnFilesInfoFromPath(path);
                //DirectoryInfo[] directoryInfos = fileEdit.ReturnFoldersInfoFromPath(path);
                string[] filesInFolder = fileEdit.allFilesAndFolders(path);
                MessageBox.Show("filesInFolder: "+ filesInFolder.Length);

                if (filesInFolder.Length > 0)
                {
                    int h = 0;
                    foreach( string str in filesInFolder)
                    {
                        h++;
                        FileInfo file = new(str);
                        StackPanel stackPanel = new();
                        CreateLineOffData(file,h);
                    }
                }

                if (Directory.Exists(path))
                {
                    MessageBox.Show("Exist: " );
                }
                else
                {
                    MessageBox.Show("path: " + path);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex+""); }
        }

        private bool CreateLineOffData(FileInfo fileInfo, int number)
        {
            if (number < 1) return false;
            try
            {

            Grid grid = this.GridTableForData;
            Label labelFileName = new();
            labelFileName.Name = "FileName";
            labelFileName.Padding = new (2);
            labelFileName.MaxWidth = 130;
            labelFileName.Content = "aaaaaaaaaaaaaaa";

            //grid.SetRow(labelFileName,number);
            //grid.SetColumn(labelFileName,1);

            Label labelFileSize = new();
            labelFileSize.Name = "FileName";
            labelFileSize.Padding = new(2);
            labelFileSize.MaxWidth = 130;
            labelFileSize.Content = "aaaaaaaaaaaaaaa";

            Grid.SetRow(labelFileName, number);
            Grid.SetColumn(labelFileName, 2);


            Button buttonOpen = new();
            buttonOpen.Content = "OPEN";
            buttonOpen.Click += OpenFile;

            Button buttonDelete = new();
            buttonDelete.Content = "DELETE";
            buttonDelete.Click += DeleteFile;

            StackPanel stackPanel = new();
            stackPanel.Children.Add(buttonOpen);
            stackPanel.Children.Add(buttonDelete);

            Grid.SetRow(stackPanel, number);
            Grid.SetColumn(stackPanel, 3);

            //this.GridTableForData.Children.Add(Grid);
            }catch(Exception ex) { MessageBox.Show("Error: " + ex); }
            return true;
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteFile(object sender, RoutedEventArgs e)
        {

        }
    }
}
