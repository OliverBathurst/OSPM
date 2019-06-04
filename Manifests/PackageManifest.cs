using System;
using System.Collections.Generic;

[Serializable]
public class PackageManifest : IManifest {
    public List<Operation> Operations;
    public bool? CompressionEnabled { get; set; }
    public bool? EnforceHashCheck { get; set; }
    public string Hash { get; set; }
    public string Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //manifest name (file name) will be set by the program and won't be in the manifest itself
    public string ManifestName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}