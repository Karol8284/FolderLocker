using System;
using System.Collections.Generic;
using System.Windows;

namespace FolderLocker.AppLogic.Data
{
    internal class FonctionsForData
    {
        public FonctionsForData() { }
        public void FreturnAllDataAsMessangeBox(List<int> list)
        {
            foreach (var item in list)
            {
                MessageBox.Show(item.GetType+": "+ item);
            }
        }
    }
}
