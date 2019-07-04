using System;
using Newtonsoft.Json;

[Serializable]
public class Install {
    [JsonProperty(PropertyName = "AppManifestPath")]
    public string AppManifestPath { get; set; }
}