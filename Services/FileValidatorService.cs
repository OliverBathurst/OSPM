using System;
using System.IO;
public class FileValidatorService : IFileValidatorService {
    public FileValidatorService(){}

    public bool ValidateFilePath(string filePath, FileType fileType = FileType.Undefined){
        if(fileType == FileType.Package){
            if(!File.Exists(filePath)){
                throw new Exception("File does not exist");
            }
            if(Path.GetExtension(filePath) != ".netpac"){
                throw new Exception($"{filePath} does not have the correct extension");
            }
            return true;
        }else{
            if(!File.Exists(filePath)){
                throw new Exception("File does not exist");
            }else{
                return true;
            }
        }
    }
}