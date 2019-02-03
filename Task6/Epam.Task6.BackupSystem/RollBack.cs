using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class RollBack
    {
        public static void Run()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory + @"\..\..\TestFolder");

            foreach (FileInfo f in dirInfo.GetFiles())
            {
                f.Delete();
            }

            var files = dirInfo.GetFiles();
            foreach (var item in files)
            {

            }
        }
    }
}
