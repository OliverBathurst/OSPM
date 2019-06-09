using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class PackageManifest : IManifest {
    [JsonProperty(PropertyName = "Operations")]
    public List<Operation> Operations;
    [JsonProperty(PropertyName = "EnforceHashCheck")]
    public bool? EnforceHashCheck { get; set; }
    [JsonProperty(PropertyName = "Hash")]
    public string Hash { get; set; }
    [JsonProperty(PropertyName = "Version")]
    public string Version { get; set; }
    public string ManifestPath { get; set; }
}