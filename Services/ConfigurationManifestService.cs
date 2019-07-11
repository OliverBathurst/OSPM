using System;
using System.IO;
public class ConfigurationManifestService : IConfigurationManifestService {
    private readonly IConfigurationFileProcessorService _configurationFileProcessorService;
    private static string CONFIG_PATH = "netconfig.json";
    public ConfigurationManifestService(){
        _configurationFileProcessorService = StaticData.Get<IConfigurationFileProcessorService>();
    }

    public ConfigurationManifest GetConfig(){
        return File.Exists(CONFIG_PATH) ? _configurationFileProcessorService.Process(CONFIG_PATH) : null;  
    }

    public string GetWorkingDirectory(){
        var config = GetConfig();
        
        if(!Directory.Exists(config.WorkingDir)){            
            throw new Exception($"Unable to open the working directory {config.WorkingDir}");
        }
        return config.WorkingDir;
    }
}