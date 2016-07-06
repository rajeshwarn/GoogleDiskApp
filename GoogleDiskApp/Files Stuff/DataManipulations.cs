using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
                    string text = file.path + "|" + file.name + "|" + file.lastModyfication;
                    writer.WriteLine(text);
                }
            }
        }

        public static List<Sheaf> CheckForModyfications(List<Sheaf> oldFiles, List<Sheaf> actualFiles)
        {
            List<Sheaf> modyficatedFiles = new List<Sheaf>();
            int temp = oldFiles.Count;
            //if (files.Count >= actualFiles.Count)
            //{
            //    temp = files.Count;
            //}
            //else if (files.Count < actualFiles.Count)
            //{
            //    temp = actualFiles.Count;
            //}

            for (int i = 0; i < temp; i++)
            {
                if (oldFiles[i].name == actualFiles[i].name)
                {
                    long oldTicks = long.Parse(oldFiles[i].lastModyfication.Ticks.ToString().Substring(0, 11)),
                        newTicks = long.Parse(actualFiles[i].lastModyfication.Ticks.ToString().Substring(0, 11)); 
                    //usunięcie ostatnich 7 znaków a nie substring

                    if (oldTicks < newTicks)
                    {
                        modyficatedFiles.Add(actualFiles[i]);
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
                        path = d[0],
                        name = d[1],
                        lastModyfication = DateTime.ParseExact(d[2], "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    };
                })
                .ToList();
        }
    }
}
