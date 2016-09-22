using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;

namespace GoogleDiskApp.Files_Stuff
{
    class GoogleDriveUpload
    {
        //Check for already existing file "Daimto.GoogleDrive.Auth.Store"
        private static DriveService AutenthicationGoogleDrive()
        {
            //Scopes for use with the Google Drive API
            string[] scopes = new string[]
            {
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile
            };
            var clientId = "660688416909-iupbi3tm38bu89a3ij05q8o5spj5chn1.apps.googleusercontent.com";
                // From https://console.developers.google.com
            var clientSecret = "i4vPiaa4rmwq6Gc07lI2Nken"; // From https://console.developers.google.com
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
                scopes,
                Environment.UserName,
                CancellationToken.None,
                new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Drive Uploader",
            });
        }

        private static string GetMimeType(string filePath)
        {
            string mimeType = "application/unknown";
            var extension = System.IO.Path.GetExtension(filePath);
            if (extension != null)
            {
                string ext = extension.ToLower();
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                    mimeType = regKey.GetValue("Content Type").ToString();
            }
            return mimeType;
        }

        public static List<Sheaf> UploadFile(List<Sheaf> listToUpload)
        {
            var service = AutenthicationGoogleDrive();

            foreach (var data in listToUpload)
            {
                File fileToUpload = new File
                {
                    Name = data.Name,
                    MimeType = GetMimeType(data.Path),
                };

                if (data.FolderID != null && IsFolderAvaliable(service, data.FolderID))
                {
                    fileToUpload.Parents = data.Parents();
                }
                else
                {
                    string parent = ParentIdFinder(service, data);
                    data.FolderID = parent;
                    fileToUpload.Parents = data.Parents();
                }
                
                byte[] byteArray = System.IO.File.ReadAllBytes(data.Path);
                MemoryStream stream = new MemoryStream(byteArray);

                try
                {
                    FilesResource.CreateMediaUpload request = service.Files.Create(fileToUpload, stream,
                        fileToUpload.MimeType);
                    request.Upload();
                    MessageBox.Show("Uploaded");

                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occurred: " + e.Message);
                }
            }
            return listToUpload;
        }

        private static string ParentIdFinder(DriveService service, Sheaf file)
        {
            List<string> folderList = GetFolderList(file.Path);
            FileList list = new FileList();
            Stack<string> folderStack = new Stack<string>();
            string parentID = null;

            foreach (var folder in folderList)
            {
                var request = service.Files.List();
                request.Q = "mimeType='application/vnd.google-apps.folder' and trashed = false and name = '" + folder + "'";
                request.Fields = "nextPageToken, files(id, name, parents)";
                list = request.Execute();

                if (list.Files.Count != 0)
                {
                    break;
                }
                folderStack.Push(folder);
            }

            if (folderStack.Count != 0)
            {
                string tempParentId = "0ALQqR9_eO7xFUk9PVA";
                if (list.Files.Count != 0)
                {
                    tempParentId = list.Files[0].Id;
                }
                parentID = LastParentId(service, folderStack, tempParentId);
            }
            else
            {
                parentID = list.Files[0].Id;
            }

            return parentID;
        }

        private static List<string> GetFolderList(string filePath)
        {
            string path = filePath;
            var slash = path.LastIndexOf("\\", StringComparison.Ordinal);
            path = path.Remove(slash);

            bool folderAvability = true;
            List<string> folderList = new List<string>();

            while (folderAvability)
            {
                slash = path.LastIndexOf("\\", StringComparison.Ordinal);

                slash++;
                string tempFolder = path.Substring(slash);
                folderList.Add(tempFolder);

                slash--;
                path = path.Remove(slash);

                if (slash == 2)
                {
                    folderAvability = false;
                }
            }

            return folderList;
        }

        private static string LastParentId(DriveService service, Stack<string> folderStack, string parentID)
        {
            var folder = new File();
            string tempParentId = "";

            for (int i = 0, count = folderStack.Count; i < count; i++)
            {
                string folderName = folderStack.Pop();
                folder.Name = folderName;
                folder.MimeType = "application/vnd.google-apps.folder";
                if (i == 0)
                {
                    folder.Parents = new List<string>() {parentID};
                }
                else
                {
                    folder.Parents = new List<string>() {tempParentId};
                }

                var request = service.Files.Create(folder);
                request.Fields = "id";
                var tempFolder = request.Execute();
                tempParentId = tempFolder.Id;
            }

            return tempParentId;
        }

        private static bool IsFolderAvaliable(DriveService service, string parentId)
        {
            var request = service.Files.List();
            request.Q = "mimeType='application/vnd.google-apps.folder' and '"+ parentId +"' in parents and trashed = false";
            request.Fields = "files(id)";
            FileList list = new FileList();
            try
            {
                list = request.Execute();
            }catch (Exception e){

                MessageBox.Show(e.Message);
            }

            if (list.Files.Count != 0)
            {
                return true;
            }
            return false;
        }

        public static void Test()
        {
            var service = AutenthicationGoogleDrive();
            var req = service.Files.List();
            req.Q = "mimeType='application/vnd.google-apps.folder' and name = 'Piastonalia' or name = 'studia' and trashed = false";
            req.Fields = "files(parents)";
            var list = req.Execute();
            MessageBox.Show(list.Files[0].Name +":"+list.Files[0].Parents[0] + Environment.NewLine + list.Files[0].Name + ":" + list.Files[1].Parents[0]);
        }
    }
}
