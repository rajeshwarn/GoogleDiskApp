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
using System.Xml.Serialization;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Json;
using Org.BouncyCastle.Asn1.Crmf;
using File = System.IO.File;

namespace GoogleDiskApp.Files_Stuff
{
    class DataManipulations
    {
        private static readonly string[] _files = Directory.GetFiles(@"C:\\test", "*.*", SearchOption.AllDirectories);
        private static readonly string _path = Environment.CurrentDirectory + "\\list.xml";
        private static readonly XDocument _xmlDoc = XDocument.Load(_path);

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

        public static List<Sheaf> CheckForModyfications()
        {
            List<Sheaf> filesToUploadList = new List<Sheaf>();
            var actualFileList = GetListOfFiles();
            var uploadFileList = ReadFromXml();

            foreach (Sheaf file in uploadFileList)
            {
                foreach (Sheaf sheaf in actualFileList)
                {
                    if (file.Path == sheaf.Path)
                    {
                        int dateCompare = DateTime.Compare(file.LastModyfication, sheaf.LastModyfication);

                        if (dateCompare == 1)
                        {
                            sheaf.FolderId = file.FolderId;
                            filesToUploadList.Add(sheaf);
                        }
                        actualFileList.Remove(sheaf);
                        break;
                    }
                }
            }

            filesToUploadList.AddRange(actualFileList);

            filesToUploadList = filesToUploadList.OrderBy(file => file.Path).ToList();

            return filesToUploadList;
        }

        public static void UpdateXmlLog(List<Sheaf> fileList)
        {
            //znalezienie elementu
            var listFromXml = new List<Sheaf>();
            try
            {
                listFromXml = ReadFromXml();
            }
            catch (Exception e)
            {

            }
            finally
            {
                foreach (Sheaf sheaf in fileList)
                {
                    var contain = listFromXml.Contains(sheaf);
                    if (contain)
                    {
                        //dopisanie go do xmla
                        AddToXml(sheaf);
                        fileList.Remove(sheaf);
                    }
                }

                //dopisanie reszty elementow do xmla
                AddToXml(fileList);
            }
        }

        private static void AddToXml(List<Sheaf> fileList)
        {
            var serializer = new XmlSerializer(typeof(List<Sheaf>));
            var stream = new StreamWriter(_path);
            serializer.Serialize(stream, fileList);
        }

        private static void AddToXml(Sheaf sheaf)
        {
            var root = _xmlDoc.Root;
            var data = from el in root.Elements("Sheaf")
                where (string) el.Element("Path") == sheaf.Path
                select el;

            foreach (XElement el in data)
            {
                el.Element("Path").Value = sheaf.Path;
                
            }
            
        }

        private static List<Sheaf> ReadFromXml()
        {
            var fileList = _xmlDoc.Descendants("Sheaf").Select(f =>
            {
                var sheaf = new Sheaf
                {
                    Name = f.Element("Name").Value,
                    Path = f.Element("Path").Value,
                    LastModyfication = DateTime.Parse(f.Element("LastModyfication").Value)
                };

                var tempFolderId = f.Element("FolderId");
                if (tempFolderId != null && tempFolderId.Value == "")
                {
                    sheaf.FolderId = tempFolderId.Value;
                }

                return sheaf;
            }).ToList();

            return fileList;
        }

        private static List<Sheaf> GetListOfFiles()
        {
            return (from path in _files let fileInfo = new FileInfo(path) select new Sheaf(path, fileInfo.Name, fileInfo.LastWriteTime)).ToList();
        }

    }
}

