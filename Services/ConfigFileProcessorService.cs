using System;
using System.IO;
using Json.Net;

public class ConfigFileProcessorService {
    public ConfigFileProcessorService(){}
    public ConfigurationManifest Process(string filePath){
        var deserialised = JsonNet.Deserialize<ConfigurationManifest>(File.ReadAllText(filePath));
        if(deserialised == null){
            throw new Exception($"Failed to deserialise configuration file at {filePath}");
        }else{
            deserialised.ManifestPath = filePath;
            return deserialised;
        }        
    }
}