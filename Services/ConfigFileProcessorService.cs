using System;
using System.IO;
using Json.Net;

public class ConfigFileProcessorService {
    private string FilePath;
    public ConfigFileProcessorService(){}

    public ConfigurationManifest Process(string filePath){
        return JsonNet.Deserialize<ConfigurationManifest>(File.ReadAllText(filePath));
    }
}