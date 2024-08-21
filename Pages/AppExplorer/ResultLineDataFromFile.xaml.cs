using FolderLocker.AppLogic.Files;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FolderLocker.Pages.AppExplorel
{
    /// <summary>
    /// Logika interakcji dla klasy ResultLineDataFromFile.xaml
    /// </summary>
    public partial class ResultLineDataFromFile : UserControl
    {
        public BitmapImage _FileImage;
        public BitmapImage FileImage {get; set;}
        //public string FileImagePath {get; set;}
        public string _ImgPath;
        public string ImgPath
        {
            get => _ImgPath;
            set {
                value ??= "";
                _ImgPath = value; 
            }
        }
        public string _FileName;
        public string FileName
        {
            get => _FileName;
            set {
                value ??= "";
                _FileName = value;
            }
        }
        public string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set
            {
                value ??= "";
                _FilePath = value;
            } 
        }
        public long _FileSize; 
        public long FileSize 
        {
            get => _FileSize;
            set => _FileSize = value;
        }
        
        public ResultLineDataFromFile(string imgPath, string name, string path, long size)
        {
            InitializeComponent();
            //ImageSource img = LoadImage(imgPath);
            BitmapImage img = LoadImage(imgPath);
            if(img != null)FileImage = img;
            FileName = name;
            FilePath = path;
            FileSize = size;
            //SettDataToXaml(img, name, path, size.ToString());
        }
        
        public ResultLineDataFromFile(BitmapImage img, string name, string path, long size)
        {
            try
            {

                FileImage = img;
                FileName = name;
                FilePath = path;
                FileSize = size;
                InitializeComponent();
                SettDataToXaml(img, name, path, size.ToString());

            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
}
      
        private BitmapImage LoadImage(string path)
            {
            //MessageBox.Show("path: " + path);
            if (!Directory.Exists(path)) return null;
            var uri = new Uri(path);
            BitmapImage img = new BitmapImage(uri);
            //MessageBox.Show("path: " + path +" "+ img.DependencyObjectType);
            return img;
        }
        private void SettDataToXaml(ImageSource img, string name, string path, string size)
        {
            /*
            MessageBox.Show("img: "+ img);
            MessageBox.Show("bool: "+(img == null));
            MessageBox.Show("name: "+ name);
            MessageBox.Show("path: " + path);
            MessageBox.Show("size: "+ size);

            */

            if (img != null) Image_Icon.Source = img;
            if (name != null) Label_FileName.Content = name;
            if (path != null) Label_Path.Content = path;
            if (size != null) Label_Size.Content = size;
        }
    }
}
