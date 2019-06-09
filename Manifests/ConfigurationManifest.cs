using System.Collections.Generic;
using System;
using Newtonsoft.Json;

[Serializable]
public class ConfigurationManifest : IManifest {
    [JsonProperty(PropertyName = "ServerURL")]
    public string ServerURL { get; set; }
    [JsonProperty(PropertyName = "TempDir")]
    public string TempDir { get; set; }
    [JsonProperty(PropertyName = "BackupDir")]
    public string BackupDir { get; set; }
    [JsonProperty(PropertyName = "ConfigVersion")]
    public string ConfigVersion { get; set; }
    [JsonProperty(PropertyName = "CurrentAppVersion")]
    public string CurrentAppVersion { get; set; }
    [JsonProperty(PropertyName = "CustomRegistryPaths")]
    public Dictionary<string, string> CustomRegistryPaths { get; set; }
    [JsonProperty(PropertyName = "LicenseKey")]
    public string LicenseKey { get; set; }
    [JsonProperty(PropertyName = "IgnoreWarnings")]
    public bool? IgnoreWarnings { get; set; }
    [JsonProperty(PropertyName = "ConnectionInfo")]
    public ConnectionInfo ConnectionInfo { get; set; }  
    [JsonProperty(PropertyName = "Version")]  
    public string Version { get; set; }
    public string ManifestPath { get; set; }
}