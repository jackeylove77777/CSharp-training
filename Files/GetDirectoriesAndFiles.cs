using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class GetDirectoriesAndFiles
    {
        public static void GetDirectories([CallerFilePath]string callerFile="")
        {   
            string rootPath=Path.GetDirectoryName(callerFile);
            string path = Path.Combine(rootPath, "TestDirectory");
            travelDirectory(path);

        }

        public static void GetFiles([CallerFilePath] string callerFile = "")
        {
            string rootPath = Path.GetDirectoryName(callerFile);
            string path = Path.Combine(rootPath, "TestDirectory");
            travelFiles(path);
        }
        private static void travelDirectory(string path)
        {
            var directory = new DirectoryInfo(path);
            Console.WriteLine(directory.FullName);
            foreach(var item in directory.GetDirectories())
            {
                travelDirectory(item.FullName);
            }
        }

        static void travelFiles(string path)
        {
            var directory = new DirectoryInfo(path);
            foreach(var file in directory.GetFiles())
            {
                Console.WriteLine(file.FullName);
            }
            foreach (var direc in directory.GetDirectories())
                travelFiles(direc.FullName);
        }
    }
}
