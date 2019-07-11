using System;

public class UpdateService : IUpdateService {
    private readonly IConfigurationManifestService _configurationManifestService;
    private readonly IConfigurationManifestValidatorService _configurationManifestValidatorService;
    private readonly IFileDownloaderService _fileDownloaderService;
    private readonly IFileValidatorService _fileValidatorService;
    public UpdateService(){
        _configurationManifestService = StaticData.Get<IConfigurationManifestService>();
        _configurationManifestValidatorService = StaticData.Get<IConfigurationManifestValidatorService>();
        _fileDownloaderService = StaticData.Get<IFileDownloaderService>();
        _fileValidatorService = StaticData.Get<IFileValidatorService>();
    }
    
    public void ProcessUpdate(string[] args){
        var ConfigFile = _configurationManifestService.GetConfig();
        if(args.Length == 0){            
            if(ConfigFile != null){
                _configurationManifestValidatorService.Validate(ConfigFile);                
                Update(_fileDownloaderService.GetFileURI(ConfigFile));
            }else{
                throw new Exception("No config file found");
            }    
        }else if(args.Length > 0){
            if(_fileDownloaderService.IsLocalPath(args[0])){
                if(!_fileValidatorService.ValidateFilePath(args[0], FileType.Package)){
                    throw new Exception($"Invalid file specified {args[0]}");
                }
            }     
            if(args.Length == 1){
                Update(_fileDownloaderService.GetFileURI(ConfigFile, args[0]));
            }else if(args.Length == 2){
                switch(args[1]){
                    case "-ignorewarnings":
                        Update(_fileDownloaderService.GetFileURI(ConfigFile, args[0]), true);
                        break;     
                    default:
                        throw new Exception($"Invalid argument supplied {args[1]}");               
                }            
            }else{
                throw new Exception("Invalid arguments supplied");
            }        
        }
    }

    private void Update(string filePath, bool ignoreWarnings = false){
        
    }
}