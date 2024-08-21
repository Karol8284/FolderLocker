
namespace FolderLocker.AppLogic.Files
{
    internal class Files
    {
        Files() { }
        public void Hash()
        {

        }
        public void createNewFile(string path, string name, string dataToSave)
        {
            FileEdit fileEdit = new();
            fileEdit.CreateFile(path, name, true);
            fileEdit.Write(path, dataToSave, false);
        }
        public void createNewFile(string path, string name, byte[] dataToSave)
        {
            FileEdit fileEdit = new();
            fileEdit.CreateFile(path, name, true);
            //fileEdit.Write(path, dataToSave, false);
        }
        public void selectMultipleFilesToSave()
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wybierz plik graficzny";
            openFileDialog.InitialDirectory = @"c:\"; // Możesz zmienić ścieżkę początkową
            openFileDialog.Filter = "Pliki graficzne (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif|Wszystkie pliki (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
              */  
            /*
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
            {
                string selectedFilePath = openFileDialog.FileName;
                // Teraz możesz zrobić coś z wybranym plikiem
            }
            */
        }
        public void GetDataFromFile(string path)
        {
        }
    }
}
