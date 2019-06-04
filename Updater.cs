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
                //just update using config file
            }
            var additionalArgs = args.Skip(1).ToArray();
            var context = new Context();
            switch(args[0]){                
                case "-update":
                    new UpdateService(context).ProcessUpdate(additionalArgs);                        
                    break;
                case "-restore":
                    new RestoreService(context).ProcessRestore(additionalArgs);
                    break;
                case "-delete":
                    new DeleteService(context).ProcessDelete(additionalArgs);
                    break;
                default:
                    throw new Exception("Invalid arguments supplied");
            }            
        }
    }
}
