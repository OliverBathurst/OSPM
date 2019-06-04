using System.Collections.Generic;
using System;

[Serializable]
public class ConfigurationManifest : IManifest{
    //todo add json property attributes
    public string ServerURL { get; set; }
    public string TempDir { get; set; }
    public string BackupDir { get; set; }
    public string ConfigVersion { get; set; }
    public string CurrentAppVersion { get; set; }
    
    //allow custom file paths to be defined in manifest by pointing to registry key entries
    //e.g. regpath1 : "HKEY...", so when an operation is being performed it'll replace every
    //instance of "regpath1" in the filepath to the filepath declared in the reg key
    public Dictionary<string, string> CustomRegistryPaths { get; set; }
    public string LicenseKey { get; set; }
    public bool? CompressionEnabled { get; set; }
    public bool? IgnoreWarnings { get; set; }
    public ConnectionInfoManifest ConnectionInfo { get; set; }    
    public string Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //set manually, manifest name will not be in manifest, will help debugging
    public string ManifestName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}