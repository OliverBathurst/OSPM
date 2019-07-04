using System.Linq;
using System.Xml.Linq;
using System;

namespace NetUpdater
{
    class Updater
    {
        static void Main(string[] args)
        {         
            if(args.Length == 0){
                new UpdateService(new Context()).ProcessUpdate(new string[0]);
            }
            var additionalArgs = args.Skip(1).ToArray();
            switch(args[0]){   
                case "-uninstall":
                    new UninstallService(new Context()).ProcessUninstall(additionalArgs);                        
                    break;             
                case "-update":
                    new UpdateService(new Context()).ProcessUpdate(additionalArgs);                        
                    break;
                case "-restore":
                    new UpdateService(new Context()).ProcessUpdate(additionalArgs);
                    break;
                case "-delete":
                    new DeleteService(new Context()).ProcessDelete(additionalArgs);
                    break;
                case "-register":
                    new ManifestRegistrationService(new Context(), true).ProcessRegistration(additionalArgs);
                    break;
                case "-unregister":
                    new ManifestRegistrationService(new Context(), false).ProcessRegistration(additionalArgs);
                    break;
                default:
                    throw new Exception("Invalid arguments supplied");
            }            
        }
    }
}
