using System;
using Newtonsoft.Json;

[Serializable]
public class ConnectionInfo {
    [JsonProperty(PropertyName = "UserName")]
    public string UserName { get; set; }
    [JsonProperty(PropertyName = "Password")]
    public string Password { get; set; }
}