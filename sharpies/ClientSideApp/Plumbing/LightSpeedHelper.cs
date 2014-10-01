using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using ClientSideApp.Models;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Logging;
using Mindscape.LightSpeed.Search;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace ClientSideApp.Plumbing
{
    public class LightSpeedHelper
    {
        public static LightSpeedContext<LightSpeedModelUnitOfWork> GetLightSpeedContext()
        {
            //create folder  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/SearchEngine")
            //if not exists
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference("searchindex");
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();

          var path =  rootDir.StorageUri.PrimaryUri.ToString();
      
        
            return new LightSpeedContext<LightSpeedModelUnitOfWork>
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                IdentityMethod = IdentityMethod.IdentityColumn,
                AutoTimestampMode = AutoTimestampMode.Utc,
                QuoteIdentifiers = true,
                SearchEngine = new SearchEngineBroker(new LuceneSearchEngine()),
                SearchEngineFileLocation = path,
                DataProvider = DataProvider.SqlServer2012,
                Logger = new TraceLogger()
            };
        }
    }
}