using System;
public class ManifestRegistrationService : IManifestRegistrationService {
    private readonly bool IsRegistering;
    public ManifestRegistrationService(bool isRegistering){
        IsRegistering = isRegistering;
    }
    public void ProcessRegistration(string[] args){
        if(args.Length != 1){
            throw new Exception("Invalid arguments supplied");
        }

        ServiceProvider.GetService<IConfigurationFileProcessorService>().Process(args[0]);
        new InstallsService().Install(args[0]);
    }
}