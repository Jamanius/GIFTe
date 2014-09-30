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

namespace ClientSideApp.Plumbing
{
    public class LightSpeedHelper
    {
        public static LightSpeedContext<LightSpeedModelUnitOfWork> GetLightSpeedContext()
        {
            //create folder  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/SearchEngine")
            //if not exists

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "/SearchEngine");
            Directory.CreateDirectory(path);

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