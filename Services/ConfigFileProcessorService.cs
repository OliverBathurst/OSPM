using System;
using System.IO;
using Json.Net;

public class ConfigFileProcessorService : IConfigFileProcessorService{
    public ConfigFileProcessorService(){}
    public ConfigurationManifest Process(string filePath){
        if(filePath == null || Path.GetExtension(filePath) != ".json"){
            throw new Exception($"Failed to open configuration file at {filePath}");
        }

        var deserialised = JsonNet.Deserialize<ConfigurationManifest>(File.ReadAllText(filePath));
        if(deserialised == null){
            throw new Exception($"Failed to deserialise configuration file at {filePath}");
        }else{
            deserialised.ManifestPath = filePath;
            return deserialised;
        }        
    }
}