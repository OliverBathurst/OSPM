using System;
using System.Collections.Generic;
public class ConfigurationManifestValidatorService : IValidator<ConfigurationManifest>, IConfigurationManifestValidatorService {
    public ConfigurationManifestValidatorService(){}

    public List<KeyValuePair<MessageType, string>> Validate(ConfigurationManifest config){
        if(config == null)
            throw new Exception("Configuration manifest is null");
        return new List<KeyValuePair<MessageType, string>>();
    }
}