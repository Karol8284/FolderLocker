using FolderLocker.AppLogic.Dictionarys;
using FolderLocker.Data.AppVariables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace FolderLocker.Pages.AppExplorel
{
    internal class SearchClass
    {
        private string Searching_Path { get; set;}
        private string Searching_ForFileName { get; set;}
        
        private bool Searching_Folders{get; set;}
        private bool Searching_Files{get; set;}
        private bool Searching_Images{get; set;}
        private bool Searching_Videos{get; set;}
        private bool Searching_Gifs{get; set;}
        
        private bool Searching_EncryptetByUser{get; set;}
        private bool Searching_AccessibleForUser{get; set;}

        private string FileName { get; set;}
        private string FilePath { get; set;}
        private long FileSize { get; set;}
        
        private string IconPath { get; set;}
    
        List<ResultLineDataFromFile> ElementsToLoadWindowList = new();
        public SearchClass() { }
        /// <summary>
        ///   aaaaaaaaaa  
        /// </summary>
        /// <param name="Searching_ForFileName"></param>
        /// <param name="Searching_Folders"></param>
        /// <param name="Searching_Files"></param>
        /// <param name="Searching_Images"></param>
        /// <param name="Searching_Videos"></param>
        /// <param name="Searching_Gifs"></param>
        /// 
        /// <param name="Searching_EncryptetByUser"></param>
        /// <param name="Searching_AccessibleForUser"></param>
        
        public List<ResultLineDataFromFile> Search(string pathToSearch, string fileNameToSeach, bool search_ForFolders, bool search_Files, bool search_Images,
            bool search_Videos, bool search_Gifs, bool search_EncryptetByUser, bool search_AccessibleForUser) 
        {
            if (pathToSearch == "" || pathToSearch == null) pathToSearch = @"C:\";
            GlobalAppVariables globalAppVariables = new();
            Searching_Path = pathToSearch;
            Searching_ForFileName = fileNameToSeach;
            
            Searching_Folders = search_ForFolders;
            Searching_Files = search_Files;
            Searching_Images = search_Images;
            Searching_Videos = search_Videos;
            Searching_Gifs = search_Gifs;

            Searching_EncryptetByUser = search_EncryptetByUser;
            Searching_AccessibleForUser = search_AccessibleForUser;

            string[] listOfAllElements;
            try
            {
                if (Searching_Path.Length == 0) Searching_Path = @"C:\";
                if(Searching_ForFileName.Length == 0)
                {
                    if (!Directory.Exists(Searching_Path)) return null;
                    listOfAllElements = Directory.GetFiles(Searching_Path);
                    if (listOfAllElements.Length == 0) return null;
                    foreach (var item in listOfAllElements)
                    {
                        FilePath = Path.GetDirectoryName(item);
                        FilePath ??= "";
                        FileName = Path.GetFileName(item);

                        FileInfo f = new FileInfo(item);
                        FileSize = f.Length;
                        FilesTypes filesTypes = new FilesTypes();
                        string IconPath = filesTypes.ReturnPathToIcons(item);

                        if (IconPath == null) IconPath = globalAppVariables.AppMainIconNotFoundPath;

                        ResultLineDataFromFile resultLineDataFromFile = 
                            new(IconPath,FileName,FilePath,FileSize);
                        //MessageBox.Show("resultLineDataFromFile: " + resultLineDataFromFile.FileName);
                        ElementsToLoadWindowList.Add(resultLineDataFromFile);
                    }
                    foreach (ResultLineDataFromFile item in ElementsToLoadWindowList)
                    {
                        MessageBox.Show("item: " + item.FileName);
                    }
                    return ElementsToLoadWindowList;
                }
                else
                {
                    //MessageBox.Show("Search3.2");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("EX: "+ex);
                return null;
            }
            foreach (var item in ElementsToLoadWindowList)
            {
                //MessageBox.Show("element : " + item);
            }
            return null;
        }
        public FileInfo[] SearchAllInFolder(string path) 
        { 
            DirectoryInfo directoryInfo = new (path);
            FileInfo[] fileInfo = directoryInfo.GetFiles("*.*");
            return fileInfo;
        }

    }
}
