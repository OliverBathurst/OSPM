using System.IO;
using System.Net;
using System.Text.RegularExpressions;

public class FileDownloaderService {
    public FileDownloaderService(){}
    public string GetFileURI(ConfigurationManifest config, string path = null){
        var FilePath = path != null ? path : config.ServerURL;
        if(IsLocalPath(FilePath)){
            return FilePath;
        }else{
            return DownloadRemoteUpdate(config, path);
        }
    }

    public bool IsLocalPath(string uri){
        if(uri.Contains("www.") || uri.Contains("http://") || uri.Contains("https://") || uri.Contains(".co")
        || new Regex("^(https?://)?(((www\\.)?([-a-z0-9]{1,63}\\.)*?[a-z0-9][-a-z‌​0-9]{0,61}[a-z0-9]\\‌​.[a-z]{2,6})|((\\d{1‌​,3}\\.){3}\\d{1,3}))‌​(:\\d{2,4})?(/[-\\w@‌​\\+\\.~#\\?&/=%]*)?$‌​").IsMatch(uri)){
            return false;
        }else{
            return true;
        }
    }

    private string DownloadRemoteUpdate(ConfigurationManifest config, string fpath){        
        var path = string.Empty;
        if(config.TempDir != null){
            path = config.TempDir;
        }

        using (var client = new WebClient()){
            if(config.ConnectionInfo.UserName != null
                && config.ConnectionInfo.Password != null){
                client.Credentials = new NetworkCredential(config.ConnectionInfo.UserName, config.ConnectionInfo.Password);
            }
        
            client.DownloadFile(config.ServerURL, path);

            return path;            
        }
    }
}