using System;
using System.Collections.Generic;
using System.IO;
public class ConfigurationManifestValidatorService : IValidator<ConfigurationManifest> {
    public ConfigurationManifestValidatorService(){}

    public Dictionary<MessageType, string> Validate(ConfigurationManifest config){
        return new Dictionary<MessageType, string>();
    }
}