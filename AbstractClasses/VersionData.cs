using System;
using Newtonsoft.Json;

[Serializable]
public abstract class VersionData {
    [JsonProperty(PropertyName = "Version")]
    string Version { get; set; }
    [JsonProperty(PropertyName = "Hash")]
    string Hash { get; set; }
    [JsonProperty(PropertyName = "FileName")]
    string FileName { get; set; }
}