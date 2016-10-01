using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Org.BouncyCastle.Asn1.Crmf;

namespace GoogleDiskApp.Files_Stuff
{
    class DataManipulations
    {
        private static readonly string[] Paths = Directory.GetFiles(@"c:\\test", "*.*", SearchOption.AllDirectories);
        private static string _path = Environment.CurrentDirectory + "\\list.xml";

        public static List<Sheaf> GetListOfFiles()
        {
            return (from path in Paths let fileInfo = new FileInfo(path) select new Sheaf(path, fileInfo.Name, fileInfo.LastWriteTime)).ToList();
        }

        //public static void CreateFilesLog(List<Sheaf> fileList)
        //{
        //    string path = Environment.CurrentDirectory;
        //    var list = ReadFromFile(path + "\\list.txt");

        //    for (int i = 0, count = list.Count; i < count; i++)
        //    {
        //        Sheaf fileFromTxt = list[i];
        //        for (int j = 0, length = fileList.Count; j < length; j++)
        //        {
        //            Sheaf file = fileList[j];

        //            //if (fileFromTxt.Path) ;
        //        }
        //    }

        //    //using (StreamWriter writer = new StreamWriter(path + @"\list.txt"))
        //    //{
        //    //    foreach (Sheaf file in fileList)
        //    //    {
        //    //        string text = file.Path + "|" + file.Name + "|" + file.LastModyfication;

        //    //        if (!string.IsNullOrEmpty(file.FolderId))
        //    //        {
        //    //            text = text + "|" + file.FolderId;
        //    //        }

        //    //        writer.WriteLine(text);
        //    //    }
        //    //}
        //}

        //public static List<Sheaf> ReadFromFile(string filePath)
        //{
        //    return File.ReadAllLines(filePath)
        //        .Select(line =>
        //        {
        //            var d = line.Split('|');

        //            var sheaf = new Sheaf
        //            {
        //                Path = d[0],
        //                Name = d[1],
        //                LastModyfication =
        //                    DateTime.ParseExact(d[2], "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
        //            };

        //            if (d.Length == 4)
        //            {
        //                sheaf.FolderId = d[3];
        //            }

        //            return sheaf;
        //        })
        //        .ToList();
        //}

        public static List<Sheaf> CheckForModyfications(List<Sheaf> oldFiles, List<Sheaf> actualFiles)
        {
            List<Sheaf> modyficatedFiles = new List<Sheaf>();

            for (int i = 0, count = oldFiles.Count; i < count; i++)
            {
                Sheaf oldFile = oldFiles[i];

                for (int j = 0, length = actualFiles.Count; j < length; j++)
                {
                    
                    Sheaf newFile = actualFiles[j];

                    if (oldFile.Path == newFile.Path)
                    {

                        string oldTicks = oldFile.LastModyfication.Ticks.ToString(),
                            newTicks = newFile.LastModyfication.Ticks.ToString();

                        oldTicks = oldTicks.Remove(oldTicks.Length - 7);
                        newTicks = newTicks.Remove(newTicks.Length - 7);

                        long oldTicksParsed = long.Parse(oldTicks),
                            newTicksParsed = long.Parse(newTicks);

                        if (oldTicksParsed < newTicksParsed)
                        {
                            newFile.FolderId = oldFile.FolderId;
                            modyficatedFiles.Add(newFile);
                        }
                        
                        actualFiles.RemoveAt(j);

                        break;
                    }
                }
            }

            modyficatedFiles.AddRange(actualFiles);

            modyficatedFiles = modyficatedFiles.OrderBy(file => file.Path).ToList();

            return modyficatedFiles;
        }

        public static void UpdateFileLog(List<Sheaf> fileList)
        {
            
            var writer = new XmlTextWriter(_path, null);

            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            writer.WriteStartDocument();
            writer.WriteStartElement("files");

            foreach (Sheaf file in fileList)
            {
                writer.WriteStartElement("file");

                writer.WriteStartElement("name");
                writer.WriteString(file.Name);
                writer.WriteEndElement();

                writer.WriteStartElement("path");
                writer.WriteString(file.Path);
                writer.WriteEndElement();

                writer.WriteStartElement("date");
                writer.WriteString(file.LastModyfication.ToString(CultureInfo.InvariantCulture));
                writer.WriteEndElement();

                if (!string.IsNullOrEmpty(file.FolderId))
                {
                    writer.WriteStartElement("folderId");
                    writer.WriteString(file.FolderId);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static List<Sheaf> ReadFromXML()
        {
            
        } 
    }
}
