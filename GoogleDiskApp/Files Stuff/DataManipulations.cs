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
        private static readonly string _fileName = "list.xml";
        

        public static List<Sheaf> CheckForModyfications(List<Sheaf> filesOnDriveList, List<Sheaf> filesInXmlList)
        {
            List<Sheaf> filesToUploadList = new List<Sheaf>();
            var removeList = new List<Sheaf>();

            foreach(Sheaf file in filesOnDriveList)
            {
                foreach (Sheaf sheaf in filesInXmlList)
                {
                    if (file.Path == sheaf.Path)
                    {
                        int dateCompare = DateTime.Compare(file.LastModyfication, sheaf.LastModyfication);

                        if (dateCompare == 1)
                        {
                            sheaf.FolderId = file.FolderId;
                            filesToUploadList.Add(sheaf);
                        }
                        removeList.Add(file);
                        break;
                    }
                }
            }

            filesOnDriveList = RemoveFilesFromList(filesOnDriveList, removeList);

            filesToUploadList.AddRange(filesOnDriveList);

            filesToUploadList = filesToUploadList.OrderBy(file => file.Path).ToList();

            return filesToUploadList;
        }

        public static void UpdateXmlLog(List<Sheaf> fileList)
        {
            var xmlList = ReadFromXml();
            var removeList = new List<Sheaf>();

            foreach(Sheaf data in fileList)
            {
                foreach (Sheaf xmlData in xmlList)
                {
                    if (data.Path == xmlData.Path)
                    {
                        AddToXml(data);
                        removeList.Add(data);
                        break;
                    }
                }
            }

            fileList = RemoveFilesFromList(fileList, removeList);

            xmlList.AddRange(fileList);
            xmlList = DeleteFromXml(xmlList);

            xmlList.OrderBy(e => e.Path).ToList();

            AddToXml(xmlList);
        }

        private static List<Sheaf> RemoveFilesFromList(List<Sheaf> listOfFiles, List<Sheaf> filesToBeRemovedList)
        {
            foreach (var trash in filesToBeRemovedList)
            {
                listOfFiles.Remove(trash);
            }
            return listOfFiles;
        }

        private static void AddToXml(List<Sheaf> fileList)
        {
            var serializer = new XmlSerializer(typeof(List<Sheaf>));
            var stream = new StreamWriter(_path);
            serializer.Serialize(stream, fileList);
            stream.Close();
        }

        private static void AddToXml(Sheaf sheaf)
        {
            var xmlDoc = XDocument.Load(_path);
            var root = xmlDoc.Root;
            var data = from el in root.Elements("Sheaf")
                where el.Element("Path").Value == sheaf.Path
                select el;

            foreach (XElement el in data)
            {
                el.Element("LastModyfication").Value = sheaf.LastModyfication.ToLongDateString();
            }
            root.Save(_fileName);
        }

        private static List<Sheaf> DeleteFromXml(List<Sheaf> xmlList)
        {
            bool isOnDrive;
            var trashList = new List<Sheaf>();
            var driveList = GetListOfFiles();
            foreach(var xmlNode in xmlList)
            {
                isOnDrive = false;
                foreach (var data in driveList)
                {
                    if (data.Path == xmlNode.Path)
                    {
                        isOnDrive = true;
                        break;
                    }
                }
                if (!isOnDrive)
                {
                    trashList.Add(xmlNode);
                }
            }
            var list = RemoveFilesFromList(xmlList, trashList);
            return list;
        }

        public static List<Sheaf> ReadFromXml()
        {
            XDocument xmlDoc = XDocument.Load(_path);
            var fileList = xmlDoc.Descendants("Sheaf").Select(f =>
            {
                var sheaf = new Sheaf
                {
                    Name = f.Element("Name").Value,
                    Path = f.Element("Path").Value,
                    LastModyfication = DateTime.Parse(f.Element("LastModyfication").Value)
                };

                var tempFolderId = f.Element("FolderId");
                if (tempFolderId != null)
                {
                    sheaf.FolderId = tempFolderId.Value;
                }

                return sheaf;
            }).ToList();

            return fileList;
        }

        public static List<Sheaf> GetListOfFiles()
        {
            return (from path in _files let fileInfo = new FileInfo(path) select new Sheaf(path, fileInfo.Name, fileInfo.LastWriteTime)).ToList();
        }

    }
}

