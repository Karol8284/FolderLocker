using FolderLocker.AppLogic.Files;
using FolderLocker.AppLogic.Hash;
using FolderLocker.AppLogic.User;
using FolderLocker.Data.AppVariables;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace FolderLock.AppLogic.Hash
{
    internal class DeHashData
    {
        private Dictionary<string, byte[]> FolderInfoHashData = new();

        private Dictionary<string, Dictionary<string, byte[]>> FolderDictionary = new();
        /*
        private Dictionary<string, Dictionary<string, byte[]>> FolderDictionary
        {
            get { return folderDictionary; }
            set => folderDictionary = value;
        }
        */
        public string[] DeHashedFile;
        public Dictionary<string, byte[]> FolderHashData { get; set; } = new();
        //private HashSet<byte[]> HashTable = new HashSet
        public string PathVariable { get; set; }
        private List<string> PathsToFilesTab;
        private string[] PathsToFiles;
        private string FileName;
        byte[] data { get; set; }
        byte[] key { get; set; }
        byte[] iv { get; set; }
        protected AESAlgorytm aes = new();
        User User { get; set; }
        GlobalAppVariables AppVariables = new();
        public DeHashData() { }
        public DeHashData(User user) 
        {
            this.User = user;
        }
        public Dictionary<string, Dictionary<string, byte[]>> DeHash(User user, string pathToFolder)
        {
            try
            {
                // Check  is data to mechod correct 
                PathsToFilesTab = new();
                if (!Directory.Exists(pathToFolder) || !File.Exists(Path.Combine(pathToFolder, "folderInfoToFolderLock.txt")) || user == null)
                {
                    MessageBox.Show("ERROR DeHashData - DeHash:  Directory not exist or file folderInfoToFolderLock exist");
                    return null;
                }
                FileEdit fileEdit = new();

                // Get data (<Dictionary<string, Dictionary<string, byte[]>>>) from folderInfoToFolderLock.txt and Decrypt 
                //string textFromFolderLockFile = "";
                //byte[] byteTabFromFolderLockFile = fileEdit.ReadAllLinesAsByteTab(Path.Combine(pathToFolder, "folderInfoToFolderLock.txt"));

                
                //byte[] byteTabFromFolderLockFile = fileEdit.ReadAllLinesAsByteTab(Path.Combine(pathToFolder, "folderInfoToFolderLock.txt"));
                string fromFolderLockFile = fileEdit.Read(Path.Combine(pathToFolder, "folderInfoToFolderLock.txt"));
                byte[] byteTabFromFolderLockFile = Convert.FromBase64String(fromFolderLockFile);
                MessageBox.Show("DeHash - fromFolderLockFile: " + fromFolderLockFile);
                if (byteTabFromFolderLockFile == null || byteTabFromFolderLockFile.Length == 0) return null;

                //Error text is not valid base-64 string ?

                user.KeysTab.TryGetValue(pathToFolder, out Dictionary<string, byte[]> value);
                value.TryGetValue("key", out byte[] folderInfoKey);
                value.TryGetValue("iv", out byte[] folderInfoIv);

                string str = aes.Decrypt(byteTabFromFolderLockFile, folderInfoKey, folderInfoIv);
                MessageBox.Show("FolderDictionary: " + str);
                FolderDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, byte[]>>>(str);

                // Get  all paths to files in folder 
                PathsToFiles = Directory.GetFiles(pathToFolder);
                foreach (var path in PathsToFiles)
                {
                    if (path == Path.Combine(pathToFolder, "folderInfoToFolderLock.txt")) continue;
                    string textFromFile = "";
                    using (StreamReader streamReader = new(path)) textFromFile = streamReader.ReadToEnd();

                    if (string.IsNullOrEmpty(textFromFile)) continue;

                    MessageBox.Show("x1: " +pathToFolder);
                    FolderDictionary.TryGetValue(pathToFolder, out Dictionary<string, byte[]> itemDictionary);
                    foreach (var item in itemDictionary)
                    {
                        MessageBox.Show(item + "");
                    }

                    try
                    {
                        FolderDictionary.TryGetValue(pathToFolder, out FolderInfoHashData);
                        FolderInfoHashData.TryGetValue("key", out byte[] keyValues);
                        key = keyValues;
                        FolderInfoHashData.TryGetValue("iv", out byte[] ivValues);
                        iv = ivValues;
                        MessageBox.Show("x2: ");
                        //DeHash data from file and wtrite decoded data to that file. And Add thata path to  PathsToFilesTab to later Remove.
                        string dataDecryptFormFile = aes.Decrypt(Convert.FromBase64String(textFromFile), key, iv);

                        MessageBox.Show("dataDecryptFormFile: " + dataDecryptFormFile);
                        MessageBox.Show("dataDecryptFormFile: " + dataDecryptFormFile);
                        fileEdit.Write(path, dataDecryptFormFile, false);
                        PathsToFilesTab.Add(path);
                    }catch(Exception ex) { MessageBox.Show(ex.ToString()); }
                    // sprawdzanie błędów np elementu nie ma w InfoFile
                    //Start Aes Decode Algorytm
                }
                foreach (string item in PathsToFilesTab)
                {
                    FolderDictionary.Remove(item);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("DeHashData - DeHash ex: " + ex);
                return FolderDictionary;
            }

            return FolderDictionary;
        }
        //protected KeyValuePair GetDataFromDatabase()
        protected Dictionary<string, byte[]> TryGetDataToAESFromDictonary(Dictionary<string, Dictionary<string, byte[]>> dictonary, string pathToCheck)
        {
            iv = new byte[1];
            FolderInfoHashData = new();
            if (dictonary.Count <= 0) return null;
            if (dictonary.TryGetValue(pathToCheck, out FolderInfoHashData))
            {
                FolderInfoHashData.TryGetValue("key", out byte[] keyValues);
                key = keyValues;
                FolderInfoHashData.TryGetValue("iv", out byte[] ivValues);
                iv = ivValues;

            }

            return FolderInfoHashData;
        }
        /*
        protected Dictionary<string, byte[]> RemovePathsFromDictonary(Dictionary<string, Dictionary<string, byte[]>> dictonary, List<string> listOfPaths)
        {
            foreach (string item in listOfPaths)
            {
                dictonary.Remove(item);
            }
        }
        */
    }
}
