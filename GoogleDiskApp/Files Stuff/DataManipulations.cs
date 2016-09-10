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
        private static readonly string Path = "c:\\test"; //Form1.Path; 
        private static readonly string[] Paths = Directory.GetFiles(@""+ Path, "*.*", SearchOption.AllDirectories);

        public static List<Sheaf> GetListOfFiles()
        {
            return (from path in Paths let fileInfo = new FileInfo(path) select new Sheaf(path, fileInfo.Name, fileInfo.LastWriteTime)).ToList();
        }

        public static void CreateFilesLog(List<Sheaf> fileList)
        {
            string path = Environment.CurrentDirectory;

            using (StreamWriter writer = new StreamWriter(path + @"\list.txt"))
            {
                foreach (Sheaf file in fileList)
                {
                    string text = file.Path + "|" + file.Name + "|" + file.LastModyfication;
                    
                    writer.WriteLine(text);
                }
            }
        }

        public static void UpdateFileLog(List<Sheaf> fileList, List<Sheaf> uploadedList)
        {
            string path = Environment.CurrentDirectory;

            using (StreamWriter writer = new StreamWriter(path + @"\list.txt"))
            {
                foreach (Sheaf file in fileList)
                {
                    string text = file.Path + "|" + file.Name + "|" + file.LastModyfication;

                    foreach (Sheaf uploaded in uploadedList)
                    {
                        if (file.Path == uploaded.Path)
                        {
                            text = text + "|" + uploaded.FolderID;
                            break;
                        }
                    }

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

                    if (d.Length == 4)
                    {
                        return new Sheaf
                        {
                            Path = d[0],
                            Name = d[1],
                            LastModyfication = DateTime.ParseExact(d[2], "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            FolderID = d[3],
                        };
                    }
                    return new Sheaf
                    {
                        Path = d[0],
                        Name = d[1],
                        LastModyfication = DateTime.ParseExact(d[2], "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
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
                    string oldPath = oldFiles[i].Path,
                        newPath = actualFiles[j].Path;

                    if (oldPath == newPath)
                    {

                        string oldTicks = oldFiles[i].LastModyfication.Ticks.ToString(),
                            newTicks = actualFiles[j].LastModyfication.Ticks.ToString();

                        oldTicks = oldTicks.Remove(oldTicks.Length - 7);
                        newTicks = newTicks.Remove(newTicks.Length - 7);

                        long oldTicksParsed = long.Parse(oldTicks),
                            newTicksParsed = long.Parse(newTicks);

                        if (oldTicksParsed < newTicksParsed)
                        {
                            actualFiles[j].FolderID = oldFiles[i].FolderID;
                            modyficatedFiles.Add(actualFiles[j]);
                        }

                        Sheaf file = actualFiles[j];
                        actualFiles.Remove(file);

                        break;
                    }
                }
            }

            modyficatedFiles.AddRange(actualFiles);

            modyficatedFiles = modyficatedFiles.OrderBy(file => file.Path).ToList();

            return modyficatedFiles;
        }

        
    }
}
