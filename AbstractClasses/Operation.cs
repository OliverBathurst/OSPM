using System;
using Newtonsoft.Json;
using System.Collections.Generic;

[Serializable]
public abstract class Operation {
    [JsonProperty(PropertyName = "OperationNumber")]
    public int OperationNumber { get; set; }
    [JsonProperty(PropertyName = "OperationType")]
    public OperationType? OperationType;
    [JsonProperty(PropertyName = "FilePaths")]
    public List<string> FilePaths { get; set; }
    [JsonProperty(PropertyName = "Destination")]
    public string Destination { get; set; }
    [JsonProperty(PropertyName = "RenameString")]
    public string RenameString { get; set; }
    //TODO: if not set, use global preference from root package manifest
    [JsonProperty(PropertyName = "IgnoreWarnings")]
    public bool IgnoreWarnings { get; set; }
    //the manifest the operation belongs to, this will be used to work out the path that a versioned file should be saved to
    //e.g. if the manifest path is C:\package\pac.json and the file path of the file is C:\package\install\d.dat
    //then then versioned container (e.g. versionedcont) will contain versioncont\package\pac.json and versioncont\package\install\d.dat
    //when making the versioned container it'll be easy to save files to it. e.g. make a new folder "temp", then store the versioned file without the drive letter.
    //e.g. saving C:\\data\file.dat to "D:\\temp" will result in the file being saved to D:\\temp\data\file.dat. 
    //Then, when generating the file path to reference when constructing the new manifest for the versioned container, 
    //simply take the container path and concatenate the filepath without the drive letter.
    //e.g. C:\\data\file.dat to versioned container "D:\\temp" will have the reference D:\\temp + C:\\data\file.dat = temp\data\file.dat, 
    //this will then be put in the manifest as the new filepath for the operation (for restoring of version)
    //the destination of the operation does not need to be changed (only the filepaths, as the files will be contained within the container)
    public IManifest Manifest { get; set; }
    public virtual (Dictionary<MessageType, string> Messages, int ErrorCount) RunOperation(){
        return (new Dictionary<MessageType, string>(), 0);
    }
    public virtual Operation GenerateReverseOperation(){
        return this;
    }
}