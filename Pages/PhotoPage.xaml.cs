using System;
using System.Windows;

namespace FolderLocker.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy PhotoPage.xaml
    /// </summary>
    public partial class PhotoPage : Window
    {
        public PhotoPage()
        {
            InitializeComponent();
        }
        public PhotoPage(string path)
        {
            InitializeComponent();
            LoadImageToPage(path);
        }
        private void GoToNextPhoto(object sender, RoutedEventArgs elib)
        {

        }
        private void GoToPreviousPhoto(object sender, RoutedEventArgs elib)
        {
            
        }
        private void GoBackToFilesExploler(object sender, RoutedEventArgs e)
        {

        }
        private void LoadImageToPage(string path)
        {

        }

    }
}
