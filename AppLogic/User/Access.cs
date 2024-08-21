using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderLocker.AppLogic.User
{
    internal class Access
    {
        /// <summary>
        ///     Always return True 
        /// </summary>
        /// <returns></returns>
        public bool isAccessableForUser()
        {
            return true;
        }
    }
}
