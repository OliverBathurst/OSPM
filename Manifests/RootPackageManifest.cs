using System;
using Newtonsoft.Json;

[Serializable]
public class RootPackageManifest : IManifest {
    [JsonProperty(PropertyName = "Hash")]
    public string Hash { get; set; }
    [JsonProperty(PropertyName = "EnforceHashCheck")]
    public bool? EnforceHashCheck { get; set; }
    [JsonProperty(PropertyName = "GlobalIgnoreWarnings")]
    public bool? GlobalIgnoreWarnings { get; set; }
    [JsonProperty(PropertyName = "Version")]
    public string Version { get; set; }
    public string ManifestPath { get; set; }
}