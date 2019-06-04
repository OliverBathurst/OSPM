using System.ComponentModel;
public class FileValidatorService {
    public FileValidatorService(){}

    public bool ValidateFilePath(string filePath, FileType fileType = FileType.Undefined){
        if(fileType == FileType.Package){
            //check file exists and file extension is correct etc
            //return true/false
        }
        //else it's a generic filetype
        //check file exists
        //return true/false
        
        return true;
    }
}