using System;
using System.Collections.Generic;
using Newtonsoft.Json;


/*  The version manifest is a simple JSON file that contains version information 
    when versioning is enabled. It should contain an array called "versions", 
    in which are multiple "version" arrays, each one denoting a different version.
    These arrays will typically contain the properties below*/

[Serializable]
public class VersionManifest {
    [JsonProperty(PropertyName = "Versions")]
    List<VersionData> Versions { get; set; }
}