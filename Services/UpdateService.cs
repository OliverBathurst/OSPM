using System;

public class UpdateService : IUpdateService {
    public UpdateService(){}
    private void Update(string filePath, bool ignoreWarnings = false){
        
    }
    public void ProcessUpdate(string[] args){
        var ConfigFile = ServiceProvider.GetService<IConfigurationManifestService>().GetConfig();
        if(args.Length == 0){            
            if(ConfigFile != null){
                ServiceProvider.GetService<IConfigurationManifestValidatorService>().Validate(ConfigFile);                
                Update(ServiceProvider.GetService<IFileDownloaderService>().GetFileURI(ConfigFile));
            }else{
                throw new Exception("No config file found");
            }    
        }else if(args.Length > 0){
            if(ServiceProvider.GetService<IFileDownloaderService>().IsLocalPath(args[0])){
                if(!ServiceProvider.GetService<IFileValidatorService>().ValidateFilePath(args[0], FileType.Package)){
                    throw new Exception($"Invalid file specified {args[0]}");
                }
            }     
            if(args.Length == 1){
                Update(ServiceProvider.GetService<IFileDownloaderService>().GetFileURI(ConfigFile, args[0]));
            }else if(args.Length == 2){
                switch(args[1]){
                    case "-ignorewarnings":
                        Update(ServiceProvider.GetService<IFileDownloaderService>().GetFileURI(ConfigFile, args[0]), true);
                        break;     
                    default:
                        throw new Exception($"Invalid argument supplied {args[1]}");               
                }            
            }else{
                throw new Exception("Invalid arguments supplied");
            }        
        }
    }
}