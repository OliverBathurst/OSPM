using System;
using System.IO;
public class ConfigurationManifestService {
    private static string CONFIG_PATH = "netconfig.json";
    public ConfigurationManifestService(){}

    public ConfigurationManifest GetConfig(){
        return File.Exists(CONFIG_PATH) ? new ConfigFileProcessorService().Process(CONFIG_PATH) : null;  
    }
}