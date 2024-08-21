using FolderLocker.Pages.AppExplorel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace FolderLocker.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy WindowFilesExplorel.xaml
    /// </summary>
    public partial class WindowFilesExplorel : Window
    {
        /// <summary>
        /// Wariables to ResultLineDataFromFile 
        /// </summary>
        public Image FileImage;

        ObservableCollection<ResultLineDataFromFile> ElementsToLoad { get; set; } = new();   
        //private List<ResultLineDataFromFile> ElementsToLoad = new();
        public List<UIElement> AllElementsToLoadWindowList { get; set; }

        public List<ResultLineDataFromFile> _ElementsToLoad
        {
            get
            {
                if (ElementsToLoad != null && ElementsToLoad.Count > 0)
                {
                    return ElementsToLoad.ToList();
                }
                return new List<ResultLineDataFromFile>();
            }
            set
            {
                if (value != null)
                {
                    ElementsToLoad = new ObservableCollection<ResultLineDataFromFile>(value);
                }
            }
        }
        string ActualPathToFolder  { get; set; }
        SearchClass AearchClass = new();
        public WindowFilesExplorel()
        {
            ActualPathToFolder = "";
            AllElementsToLoadWindowList = null;
            ElementsToLoad = null;

            InitializeComponent();
            DataContext = new WindowFilesExplorel();
            TextBox_FileNameToSearch.Text = "";
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("CheckBox_Checked");

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clear_Click");

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Search_Click");
            try
            {
                string search_path = TextBox_PathToSearch.Text;
                string search_fileName = TextBox_FileNameToSearch.Text;
                bool search_folders = (bool) (CheckBox_Folders.IsChecked ?? null);
                bool search_files = (bool) (CheckBox_Files.IsChecked ?? null);
                bool search_images = (bool) (CheckBox_Images.IsChecked ?? null);
                bool search_videos = (bool) (CheckBox_Videos.IsChecked ?? null);
                bool search_gifs = (bool) (CheckBox_Gifs.IsChecked ?? null);
                bool search_encryptedByUser = (bool) (CheckBox_EncryptedByUser.IsChecked ?? null);
                bool search_accessibleForUser = (bool) (CheckBox_AccessibleForUser.IsChecked ?? null);

                /*
                MessageBox.Show("search_path: "+ search_path);
                MessageBox.Show("search_fileName: "+ search_fileName);
                MessageBox.Show("search_folders: "+ search_folders);
                MessageBox.Show("search_files: "+ search_files);
                MessageBox.Show("search_images: "+ search_images);
                MessageBox.Show("search_videos: "+ search_videos);
                MessageBox.Show("search_gifs: " + search_gifs);
                MessageBox.Show("search_encryptedByUser: " + search_encryptedByUser);
                MessageBox.Show("search_accessibleForUser: " + search_accessibleForUser);
                */

                SearchClass searchClass = new();
                _ElementsToLoad = searchClass.Search(search_path,search_fileName
                    ,search_folders,search_files,search_images,
                    search_videos,search_gifs,search_encryptedByUser,search_accessibleForUser);

                foreach (var item in ElementsToLoad)
                {
                    MessageBox.Show("ElementsToLoad: "+ item.GetValue);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void LoadTableToWindow()
        {
            /*
            foreach (ResultLineDataFromFile item in ElementsToLoad)
            {
            MessageBox.Show("item: " + item.FileName);
            }
            */
        }
    }
}
/*
 *           <local:ResultLineDataFromFile 
FileImage = "FileImage"
FileName="FileName"
FilePath=""
FileSize="0"
/>
 */ 