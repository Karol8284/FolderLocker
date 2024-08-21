using System.IO;
using System.Windows;
using System.Windows.Navigation;

namespace FolderLocker.AppLogic.Files
{
    internal class TreePaths
    {
        /*
        TreeView treeView;
        public TreePaths() 
        {
            treeView = new();
        }
        public TreeView ReturnBranch(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    System.Windows.MessageBox.Show("ReturnBranch");
                    TreePaths treePaths = new();
                    TreeView treeView = treePaths.ReturnBranch(path);
                    string[] paths = Directory.GetDirectories(path);
                    System.Windows.MessageBox.Show("T: " + paths);

                    if (treeView == null) return null;
                    foreach (string subPath in paths) 
                        {
                    MessageBox.Show("2: 222222222222222222222");
                    TreeViewItem item = new TreeViewItem { Header = subPath};
                        treeView.Items.Add(item);
                    }

                    return treeView;
                }
                catch (Exception ex) { System.Windows.MessageBox.Show(ex+""); }
            }
            return null;
        }
        // nie skończone
        public TreeView TreePathsDeep()
        {
            if(ReturnBranch == null) return null;
            return null;
        }
        */
    }
}
