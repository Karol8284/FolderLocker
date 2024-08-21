using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.Hash;
using FolderLocker.AppLogic.User;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FolderLock.AppLogic.Hash
{
    class HashData
    {
        private Dictionary<string, byte[]> FileDictionary = new();
       
        private Dictionary<string, Dictionary<string, byte[]>> folderDictionary = new();
        private Dictionary<string, Dictionary<string, byte[]>> FolderDictionary
        {
            get { return folderDictionary; }
            set => folderDictionary = value;
        }
        public Dictionary<string, Dictionary<string, byte[]>> FolderHashData { get; set; } = new();
        public Dictionary<string, byte[]> FolderHash { get; set; } = new();
        //private HashSet<byte[]> HashTable = new HashSet
        public string PathVariable { get; set; }
        private string[] PathsToFiles;
        private string FileName;
        byte[] data { get; set; } 
        byte[] key { get; set; } 
        byte[] iv { get; set; } 
        public HashData() { }
        protected AESAlgorytm aes;
        /// <summary>
        ///     
        /// </summary>
        /// <param name="PathToFolder"></param>
        /// <param name="TypeOfHash"></param>
        public Dictionary<string, Dictionary<string, byte[]>> Hash(string pathToFolder, string typeOfHash) 
        {
            if (Directory.Exists(pathToFolder) && !File.Exists(pathToFolder + "\\folderInfoToFolderLock.txt"))
            {
                FolderHashData = new();
                FolderDictionary = new ();
                FileEdit fileEdit = new();
                AESAlgorytm aes = new();
                DPAPI dpapi = new DPAPI();
                PathsToFiles = Directory.GetFiles(pathToFolder);

                //Path.GetDirectoryName(pathToFolder);
                
                HashAllFilesInFolder(PathsToFiles);


                // Create folderInfoToFolderLock.txt file if exist over write

                if (FileDictionary == null) return null;

                string pathToFolderInfoFile = fileEdit.CreateFile(pathToFolder, "folderInfoToFolderLock.txt",false);

                string FolderDictionaryAsJson = JsonConvert.SerializeObject(FolderDictionary);
                MessageBox.Show("HashData - FolderDictionaryAsJson  : " + JsonConvert.DeserializeObject(FolderDictionaryAsJson));

                string dataToSave = "";
                // Use AES on FolderDictionaryAsJson
                aes = new();
                key = aes.returnAESKey();
                iv = aes.returnAESIv();
                data = aes.Encrypt(FolderDictionaryAsJson, key, iv);

                // Do sprawdzenia linia niżej 
                //fileEdit.Write(pathToFolderInfoFile, data);
                fileEdit.Write(pathToFolderInfoFile, Convert.ToBase64String(data), false);

                FolderHash.Add("key", aes.returnAESKey());
                FolderHash.Add("iv", aes.returnAESIv());
                FolderHashData.Add(pathToFolder, FolderHash);
            }
            return FolderHashData;
        }
        private Dictionary<string, Dictionary<string, byte[]>> HashAllFilesInFolder(string[] folderPath)
        {
            FileEdit fileEdit = new();
            foreach (string path in folderPath)
            {
                // Read all text from file
                //Check is path to folder or file  
                    string textFromFile = "";
                    using (StreamReader streamReader = new StreamReader(path)) textFromFile = streamReader.ReadToEnd();

                    // Check is textFromFile == null
                    if (string.IsNullOrEmpty(textFromFile)) continue;

                    //Start AES Algorytm  
                    aes = new();
                    key = aes.returnAESKey();
                    iv = aes.returnAESIv();
                    data = aes.Encrypt(textFromFile, key, iv);

                    FileDictionary = new();
                    FileDictionary.Add("key", key);
                    FileDictionary.Add("iv", iv);

                    fileEdit.Write(path, Convert.ToBase64String(data), false);

                    //Napisać kod zamieniające dane w file !!!

                    FolderDictionary.Add(path, FileDictionary);
                    //MessageBox.Show("!!1: ");
                    // Is file
            }
                return FolderDictionary;
        }
        private Dictionary<string, Dictionary<string, byte[]>> HashAllFilesAndFoldersInFolder(string[] folderPath)
            {
                FileEdit fileEdit = new();
                foreach (string path in folderPath)
                {
                    // Read all text from file
                    //Check is path to folder or file  

                    FileDictionary = new();
                    FileAttributes attr = File.GetAttributes(path);

                    //!!!!! NIe działa ciągle hashuje tylko pliki folderów nie przechodzi na razie olewam to dokończę jak będę miał czas 
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        // Is directory
                        PathsToFiles = Directory.GetFiles(path);
                        if (PathsToFiles.Length <= 0) continue;
                        //MessageBox.Show("!!2: ");
                        HashAllFilesAndFoldersInFolder(PathsToFiles);
                    }
                    else
                    {
                        string textFromFile = "";
                        using (StreamReader streamReader = new StreamReader(path)) textFromFile = streamReader.ReadToEnd();

                        // Check is textFromFile == null
                        if (string.IsNullOrEmpty(textFromFile)) continue;

                        //Start AES Algorytm  
                        aes = new();
                        key = aes.returnAESKey();
                        iv = aes.returnAESIv();
                        data = aes.Encrypt(textFromFile, key, iv);

                        FileDictionary.Add("key", key);
                        FileDictionary.Add("iv", iv);

                        fileEdit.Write(path, Convert.ToBase64String(data), false);

                        //Napisać kod zamieniające dane w file !!!

                        FolderDictionary.Add(path, FileDictionary);
                        //MessageBox.Show("!!1: ");
                        // Is file
                    }
                    /*
                    if (File.Exists(path))
                    {
                        string textFromFile = "";
                        using (StreamReader streamReader = new StreamReader(path))textFromFile = streamReader.ReadToEnd();

                        // Check is textFromFile == null
                        if (string.IsNullOrEmpty(textFromFile)) continue;

                        //Start AES Algorytm  
                        aes = new();
                        key = aes.returnAESKey();
                        iv = aes.returnAESIv();
                        data = aes.Encrypt(textFromFile, key, iv);

                        FileDictionary.Add("key", key);
                        FileDictionary.Add("iv", iv);

                        fileEdit.Write(path, Convert.ToBase64String(data), false);

                        //Napisać kod zamieniające dane w file !!!

                        FolderDictionary.Add(path, FileDictionary);
                        MessageBox.Show("!!1: ");
                    }
                    else if (Directory.Exists(path))
                    {
                        PathsToFiles = Directory.GetFiles(path);
                        if (PathsToFiles.Length <= 0) continue;
                        MessageBox.Show("!!2: ");
                        HashAllFilesAndFoldersInFolder(PathsToFiles);
                    }
                    */
                }


                return FolderDictionary;
        }
        public Dictionary<string, Dictionary<string, byte[]>> ReturnFolderDictionary()
        {
            return FolderDictionary;
        }
    }
}
