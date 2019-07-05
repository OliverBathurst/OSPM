using System.Linq;
using System;

namespace NetUpdater
{
    class Updater
    {
        static void Main(string[] args)
        {         
            ServiceProvider.Initialize();
            
            if(args.Length == 0){
                new UpdateService().ProcessUpdate(new string[0]);
            }
            var additionalArgs = args.Skip(1).ToArray();
            switch(args[0]){   
                case "-uninstall":
                    new UninstallService().ProcessUninstall(additionalArgs);                        
                    break;             
                case "-update":
                    new UpdateService().ProcessUpdate(additionalArgs);                        
                    break;
                case "-restore":
                    new UpdateService().ProcessUpdate(additionalArgs);
                    break;
                case "-delete":
                    new DeleteService().ProcessDelete(additionalArgs);
                    break;
                case "-register":
                    new ManifestRegistrationService(true).ProcessRegistration(additionalArgs);
                    break;
                case "-unregister":
                    new ManifestRegistrationService(false).ProcessRegistration(additionalArgs);
                    break;
                default:
                    throw new Exception("Invalid arguments supplied");
            }            
        }
    }
}
