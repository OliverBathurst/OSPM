using System;
using System.Collections.Generic;

public class DeleteService{
    private Context _context;
    public DeleteService(Context context) => _context = context;

    private void Delete(string filePath, bool ignorewarnings = false){}

    public void ProcessDelete(string[] args){
        if(args.Length == 0){
            throw new Exception("No arguments specified");
        }            

        if(!_context.FileValidatorService.ValidateFilePath(args[0])){
            throw new Exception($"Invalid file specified {args[0]}");
        }      

        if(args.Length == 1){
            Delete(args[0]);
        }else if(args.Length == 2){
            if(!_context.FlagService.GetDeleteFlags().Contains(args[1])){
                throw new Exception($"Invalid argument supplied {args[1]}");
            }
            switch(args[1]){
                case "-ignorewarnings":
                    break;
            }
        }else{
            throw new Exception("Invalid arguments supplied");
        }
    }
}