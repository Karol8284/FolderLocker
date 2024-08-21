using FolderLocker.Data.AppVariables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FolderLocker.AppLogic.Dictionarys
{

    class FilesTypes
    {

        public static readonly List<string> imageTypesList = new List<string>
        {
            ".JPG", ".JPEG", ".JPE", ".BMP", ".PNG" , ".TIFF", ".WEBP", ".SVG" , ".ICO"
        };

        public static readonly List<string> fileTypesList = new List<string>
        {
            ".TXT", ".RTF", ".LOG", ".DOCX"
        };
        GlobalAppVariables globalAppVariables = new GlobalAppVariables();
        public FilesTypes()
        {
            
        }
        /// <summary> - 1 not exist in Lists ; 1 = is in imageTypesList ; 2 = is in fileTypesList ; 3 = is Gif</summary>
        public int CheckFileType(string path)
        /// - 1 nie ma ; 0 = jest  w imageTypesList ; 1 = jest  w fileTypesList
        {
            if (File.Exists(path)) {
            }

            try
            {
                if (imageTypesList.Contains(Path.GetExtension(path).ToUpperInvariant()))
                {
                    return 1;
                }
                if (fileTypesList.Contains(Path.GetExtension(path).ToUpperInvariant()))
                {
                    return 2;
                }
                if (Path.GetExtension(path).ToUpperInvariant().Contains(".GIF"))
                {
                    return 3;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex + ""); }
            return -1;
        }
        public string ReturnPathToIcons(string path)
        {
            try
            {
                //string iconsFolderPath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName != null
                //    ? iconsFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName : return null);
                string iconsFolderPath = globalAppVariables.AppMainIconsFolderDirectory;
                /*
                if (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName != null)
                {
                    iconsFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                }
                else
                {
                    return null;
                }
                iconsFolderPath = Path.Combine(iconsFolderPath, "DataToAplication");
                */
                string GifPath = "icons8-gif-50.png";
                string TXTPath = "icons8-file-30.png";
                string ImagePath = "icons8-image-24.png";
                //MessageBox.Show("IconsFolderPath: " + iconsFolderPath);

                //MessageBox.Show("path: " + path);
                string fileType = Path.GetExtension(path).ToUpperInvariant();
                int num = CheckFileType(path);
                //MessageBox.Show("fileType: " + fileType);

                switch (fileType)
                {
                    case ".JPG":
                    case ".JPEG":
                    case ".JPE":
                    case ".BMP":
                    case ".PNG":
                    case ".TIFF":
                    case ".WEBP":
                    case ".SVG":
                    case ".ICO":
                        return Path.Combine(iconsFolderPath, ImagePath);
                    case ".TXT":
                    case ".RTF":
                    case ".LOG":
                    case ".DOCX":
                        return Path.Combine(iconsFolderPath, TXTPath);
                    case ".GIF":
                        return Path.Combine(iconsFolderPath, GifPath);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex + ""); }
        return globalAppVariables.AppMainIconNotFoundPath; ;
        }

    }
}
