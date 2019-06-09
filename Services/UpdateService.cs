using System;
using System.Collections.Generic;

public class UpdateService{
    private Context _context;
    public UpdateService(Context context) => _context = context;
    private void Update(string filePath, bool ignoreWarnings = false){
        
    }
    public void ProcessUpdate(string[] args){
        var ConfigFile = _context.ConfigurationManifestService.GetConfig();
        if(args.Length == 0){            
            if(ConfigFile != null){
                _context.ConfigurationManifestValidatorService.Validate(ConfigFile);                
                Update(_context.FileDownloaderService.GetFileURI(ConfigFile));
            }else{
                throw new Exception("No config file found");
            }    
        }else if(args.Length > 0){
            if(_context.FileDownloaderService.IsLocalPath(args[0])){
                if(!_context.FileValidatorService.ValidateFilePath(args[0], FileType.Package)){
                    throw new Exception($"Invalid file specified {args[0]}");
                }
            }     
            if(args.Length == 1){
                Update(_context.FileDownloaderService.GetFileURI(ConfigFile, args[0]));
            }else if(args.Length == 2){
                switch(args[1]){
                    case "-ignorewarnings":
                        Update(_context.FileDownloaderService.GetFileURI(ConfigFile, args[0]), true);
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