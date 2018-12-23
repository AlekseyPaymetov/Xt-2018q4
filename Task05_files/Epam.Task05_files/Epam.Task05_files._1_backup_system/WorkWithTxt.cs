using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task05_files._1_backup_system
{
    static class WorkWithTxt
    {
        public static DateTime GetDate(string name)
        {
            return DateTime.Now;
        }

        public static string CreateNewStringAfterSeparator(string oldFolder, string name,string separator)
        {
            char charSeparator = separator.ToCharArray()[0];
            int indexToCut = oldFolder.IndexOf(charSeparator);
            string newPath = oldFolder.Substring(0,indexToCut+1);
            return newPath + name;
        }
    }
}
