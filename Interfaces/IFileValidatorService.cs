public interface IFileValidatorService
{
    bool ValidateFilePath(string filePath, FileType fileType = FileType.Undefined);
}