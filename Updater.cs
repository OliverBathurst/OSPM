using System.Linq;
using System;

namespace NetUpdater
{
    class Updater
    {
        static void Main(string[] args)
        {         
            StaticData.Initialize();
            
            if(args.Length == 0){
                StaticData.Get<IUpdateService>().ProcessUpdate(new string[0]);
            }
            var additionalArgs = args.Skip(1).ToArray();
            switch(args[0]){   
                case "-uninstall":
                    StaticData.Get<IInstallsService>().ProcessUninstall(additionalArgs);                        
                    break;             
                case "-update":                
                    StaticData.Get<IUpdateService>().ProcessUpdate(additionalArgs);                        
                    break;
                case "-restore":
                    StaticData.Get<IUpdateService>().ProcessUpdate(additionalArgs);
                    break;
                case "-delete":
                    StaticData.Get<IDeleteService>().ProcessDelete(additionalArgs);
                    break;
                case "-register":
                    StaticData.Get<IManifestRegistrationService>().ProcessRegistration(additionalArgs, true);
                    break;
                case "-unregister":
                    StaticData.Get<IManifestRegistrationService>().ProcessRegistration(additionalArgs, false);
                    break;
                default:
                    throw new Exception("Invalid arguments supplied");
            }            
        }
    }
}
