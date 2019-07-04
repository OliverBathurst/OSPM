using System;
public class ManifestRegistrationService : IManifestRegistrationService {
    private readonly Context _context;
    private readonly bool IsRegistering;
    public ManifestRegistrationService(Context context, bool isRegistering){
        _context = context;
        IsRegistering = isRegistering;
    }
    public void ProcessRegistration(string[] args){
        if(args.Length != 1){
            throw new Exception("Invalid arguments supplied");
        }

        _context.ConfigurationFileProcessorService.Process(args[0]);
        new InstallsService(_context).Install(args[0]);
    }
}