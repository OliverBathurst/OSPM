using System;
using System.Collections.Generic;

public class UpdateService{
    private Context _context;
    public UpdateService(Context context) => _context = context;
    private void Update(string filePath, bool ignoreWarnings = false){

    }
    public void ProcessUpdate(string[] args){
        if(args.Length == 0){
            var ConfigFile = _context.ConfigurationManifestService.GetConfig();
            if(ConfigFile != null){
                _context.ConfigurationManifestValidatorService.Validate(ConfigFile);
                Update(_context.FileDownloaderService.GetFileURI(ConfigFile));
            }else{
                throw new Exception("No config file found");
            }    
        }else if(args.Length > 0){
            if(!_context.FileValidatorService.ValidateFilePath(args[0])){
                throw new Exception($"Invalid file specified {args[0]}");
            }
            if(args.Length == 1){                
                Update(args[0]);
            }else if(args.Length == 2){
                if(!_context.FlagService.GetUpdateFlags().Contains(args[1])){
                    throw new Exception($"Invalid argument supplied {args[1]}");
                }
                switch(args[1]){
                    case "-ignorewarnings":
                        Update(args[0], true);
                        break;                        
                }            
            }else{
                throw new Exception("Invalid arguments supplied");
            }        
        }
    }
}