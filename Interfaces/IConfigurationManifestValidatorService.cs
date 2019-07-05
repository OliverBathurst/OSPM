using System.Collections.Generic;

internal interface IConfigurationManifestValidatorService
{
    List<KeyValuePair<MessageType, string>> Validate(ConfigurationManifest config);
}