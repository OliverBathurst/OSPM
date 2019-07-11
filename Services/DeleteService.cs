using System;

public class DeleteService : IDeleteService {
    private readonly IFileValidatorService _fileValidatorService;
    public DeleteService(){
        _fileValidatorService = StaticData.Get<IFileValidatorService>();
    }
    private void Delete(string filePath, bool ignorewarnings = false){}
    public void ProcessDelete(string[] args){
        if(args.Length == 0){
            throw new Exception("No arguments specified");
        }            

        if(!_fileValidatorService.ValidateFilePath(args[0])){
            throw new Exception($"Invalid file specified {args[0]}");
        }      

        if(args.Length == 1){
            Delete(args[0]);
        }else if(args.Length == 2){
            switch(args[1]){
                case "-ignorewarnings":
                    break;
                default:
                    throw new Exception($"Invalid argument supplied {args[1]}");
            }
        }else{
            throw new Exception("Invalid arguments supplied");
        }
    }
}