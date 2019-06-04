using System;
using Newtonsoft.Json;
using System.Collections.Generic;

[Serializable]
public abstract class Operation {
    [JsonProperty(PropertyName = "OperationNumber")]
    public int OperationNumber { get; set; }
    [JsonProperty(PropertyName = "OperationType")]
    public OperationType? OperationType;
    [JsonProperty(PropertyName = "FilePath")]
    public string FilePath { get; set; }
    [JsonProperty(PropertyName = "Destination")]
    public string Destination { get; set; }
    [JsonProperty(PropertyName = "RenameString")]
    public string RenameString { get; set; }
    //TODO: if not set, use global preference from root package manifest
    [JsonProperty(PropertyName = "IgnoreWarnings")]
    public bool IgnoreWarnings { get; set; }
    public IManifest Manifest { get; set; }//the manifest the operation belongs to
    public virtual (Dictionary<MessageType, string> Messages, int ErrorCount) RunOperation(){
        return (new Dictionary<MessageType, string>(), 0);
    }
    public virtual Operation GenerateReverseOperation(){
        return this;
    }
}