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

        public static List<Sheaf> CheckForModyfications(List<Sheaf> oldFiles, List<Sheaf> actualFiles)
        {
            List<Sheaf> modyficatedFiles = new List<Sheaf>();

            for (int i = 0, count = oldFiles.Count; i < count; i++)
            {

                for (int j = 0, length = actualFiles.Count; j < length; j++)
                {
                    string oldPath = oldFiles[i].path,
                        newPath = actualFiles[j].path;

                    if (oldPath == newPath)
                    {

                        string oldTicks = oldFiles[i].lastModyfication.Ticks.ToString(),
                            newTicks = actualFiles[j].lastModyfication.Ticks.ToString();

                        oldTicks = oldTicks.Remove(oldTicks.Length - 7);
                        newTicks = newTicks.Remove(newTicks.Length - 7);

                        long oldTicksParsed = long.Parse(oldTicks),
                            newTicksParsed = long.Parse(newTicks);

                        if (oldTicksParsed < newTicksParsed)
                        {
                            modyficatedFiles.Add(actualFiles[j]);
                        }

                        Sheaf file = actualFiles[j];
                        actualFiles.Remove(file);

                        break;
                    }
                }
            }

            modyficatedFiles.AddRange(actualFiles);

            modyficatedFiles = modyficatedFiles.OrderBy(file => file.path).ToList();

            return modyficatedFiles;
        }

        
    }
}
