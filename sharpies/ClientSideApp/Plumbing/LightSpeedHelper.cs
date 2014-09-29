using System;
using System.Collections.Generic;
using System.Configuration;
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
            return new LightSpeedContext<LightSpeedModelUnitOfWork>
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                IdentityMethod = IdentityMethod.IdentityColumn,
                AutoTimestampMode = AutoTimestampMode.Utc,
                QuoteIdentifiers = true,
                SearchEngine = new SearchEngineBroker(new LuceneSearchEngine()),
                SearchEngineFileLocation = @"c:\temp\searchEngine",
                Logger = new TraceLogger()
            };
        }
    }
}