using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class InstallsManifest : IManifest
{
    [JsonProperty(PropertyName = "Installs")]
    public IEnumerable<Install> Installs { get; set; }
    public string ManifestPath { get; set ; }
    public string Version { get; set; }
}