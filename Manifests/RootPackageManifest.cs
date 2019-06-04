using System;

[Serializable]
public class RootPackageManifest : IManifest {
    public string Hash { get; set; }
    public bool? EnforceHashCheck { get; set; }
    public bool? CompressionEnabled { get; set; }
    public bool? GlobalIgnoreWarnings { get; set; }
    public string Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ManifestName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}