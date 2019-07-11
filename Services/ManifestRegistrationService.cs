using System;
public class ManifestRegistrationService : IManifestRegistrationService {
    private readonly IConfigurationFileProcessorService _configurationFileProcessorService;
    private readonly IInstallsService _installsService;
    public ManifestRegistrationService(){
        _configurationFileProcessorService = StaticData.Get<IConfigurationFileProcessorService>();
        _installsService = StaticData.Get<IInstallsService>();
    }
    public void ProcessRegistration(string[] args, bool isRegistering){
        if(args.Length != 1){
            throw new Exception("Invalid arguments supplied");
        }

        _configurationFileProcessorService.Process(args[0]);
        _installsService.Install(args[0]);
    }
}