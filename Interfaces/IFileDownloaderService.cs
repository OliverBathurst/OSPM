public interface IFileDownloaderService
{
    bool IsLocalPath(string uri);
    string GetFileURI(ConfigurationManifest config, string path = null);
}