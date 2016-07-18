using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleDiskApp.Files_Stuff
{
    class GoogleDriveUpload
    {
        public static void AutenthicationGoogleDrive()
        {
            //Scopes for use with the Google Drive API
            string[] scopes = new string[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile};
            var clientId = "660688416909-iupbi3tm38bu89a3ij05q8o5spj5chn1.apps.googleusercontent.com";      // From https://console.developers.google.com
            var clientSecret = "i4vPiaa4rmwq6Gc07lI2Nken";          // From https://console.developers.google.com
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

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });
        }   

    }
}
