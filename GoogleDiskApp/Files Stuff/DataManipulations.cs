using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoogleDiskApp.Files_Stuff
{
    class DataManipulations
    {
        private static readonly string[] Paths = Directory.GetFiles(@"c:\test\", "*.*",SearchOption.AllDirectories);

        public static List<Sheaf> GetListOfFiles()
        {
            return (from path in Paths let fileInfo = new FileInfo(path) select new Sheaf(path, fileInfo.Name, fileInfo.LastWriteTime)).ToList();
        }

        public static void CreateFilesLog(List<Sheaf> files)
        {
            string path = Environment.CurrentDirectory;

            using (StreamWriter writer = new StreamWriter(path + @"\list.txt"))
            {
                foreach (Sheaf file in files)
                {
                    string text = file.path + "|" + file.name + "|" + file.lastModyfication.ToString();
                    writer.WriteLine(text);
                }
            }
        }

        public static List<Sheaf> CheckForModyfications(List<Sheaf> files)
        {
            List<Sheaf> modyficatedFiles = new List<Sheaf>();
            List<Sheaf> actualFiles = GetListOfFiles();

            for (int i = 0, length = modyficatedFiles.Count; i < length; i++)
            {
                if (files[i].name == actualFiles[i].name)
                {
                    if (files[i].lastModyfication != actualFiles[i].lastModyfication)
                    {
                        modyficatedFiles.Add(files[i]);
                    }
                }
            }

            return modyficatedFiles;
        }

        public static List<Sheaf> ReadFromFile(string fileName)
        {
            return File.ReadAllLines(fileName)
                .Select(line =>
                {
                    var d = line.Split('|');
                    return new Sheaf
                    {
                        //dunno why...
                    };
                })
                .ToList();
        }
    }
}
