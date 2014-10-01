using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using ClientSideApp.Models;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;

namespace ClientSideApp.Plumbing
{
    public class LightspeedStartUp
    {
       

        //TODO Run Lightspeed migrations



        //TODO Search for seeds
        //Run seeds


        private static void SetupCustomLightspeedTypes()
        {
            MethodInfo method = typeof(Microsoft.SqlServer.Types.SqlGeography).GetMethod("STDistance");
            ServerFunctionDescriptor.Register(method, ".STDistance");  // note the all-important dot!

        }

        private static void RebuildLuceneIndex()
        {

            LightSpeedHelper.GetLightSpeedContext().SearchEngine.Rebuild(IsolationLevel.ReadCommitted,
            typeof(Gift));
            

        }


        public static void StartUp()
        {

           // SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));

            Task taskA = new Task(SetupCustomLightspeedTypes);
            // Start the task.
            Task taskB = new Task(RebuildLuceneIndex);
            taskA.Start();
            taskB.Start();

            
        }

        
    }
}