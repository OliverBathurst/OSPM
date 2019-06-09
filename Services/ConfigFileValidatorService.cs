using System;
using System.Collections.Generic;
using System.IO;
public class ConfigurationManifestValidatorService : IValidator<ConfigurationManifest> {
    public ConfigurationManifestValidatorService(){}

    public List<KeyValuePair<MessageType, string>> Validate(ConfigurationManifest config){
        if(config == null)
            throw new Exception("Configuration manifest is null");
        return new List<KeyValuePair<MessageType, string>>();
    }
}