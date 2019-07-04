using System;
using System.IO;
public class ConfigurationManifestService : IConfigurationManifestService {
    private static string CONFIG_PATH = "netconfig.json";
    public ConfigurationManifestService(){}

    public ConfigurationManifest GetConfig(){
        return File.Exists(CONFIG_PATH) ? new ConfigFileProcessorService().Process(CONFIG_PATH) : null;  
    }

    public string GetWorkingDirectory(){
        var config = GetConfig();
        
        if(!Directory.Exists(config.WorkingDir)){            
            throw new Exception($"Unable to open the working directory {config.WorkingDir}");
        }
        return config.WorkingDir;
    }
}