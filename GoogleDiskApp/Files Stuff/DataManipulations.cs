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
            int tempLarge = 0, tempSmall = 0;
            if (oldFiles.Count >= actualFiles.Count)
            {
                tempLarge = oldFiles.Count;
                tempSmall = actualFiles.Count;
            }
            else
            {
                tempLarge = actualFiles.Count;
                tempSmall = oldFiles.Count;
            }
            //check for any added / deleted files
            int j = 0;
            while (j < tempLarge)
            {
                bool removeFlag = false;

                for (int i = j; i < tempSmall; i++)
                {
                    if (oldFiles[j].name == actualFiles[i].name)
                    {
                        i = tempSmall;
                        j++;
                    }
                    else if ( (i + 1) == tempSmall)
                    {
                        removeFlag = true;
                    }
                }

                if (removeFlag)
                {
                    var deleteSheaf = oldFiles[j];
                    oldFiles.Remove(deleteSheaf);
                    j++;
                }
            }


            //I doubt that code
            for (int i = 0; i < tempLarge; i++)
            {
                if (oldFiles[i].name == actualFiles[i].name)
                {
                    string oldTicks = oldFiles[i].lastModyfication.Ticks.ToString(),
                        newTicks = actualFiles[i].lastModyfication.Ticks.ToString();

                    oldTicks.Remove(oldTicks.Length - 7);
                    newTicks.Remove(newTicks.Length - 7);

                    long oldTicksParsed = long.Parse(oldTicks), newTicksParsed = long.Parse(newTicks);

                    if (oldTicksParsed < newTicksParsed)
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
