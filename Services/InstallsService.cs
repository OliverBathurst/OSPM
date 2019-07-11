using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Json.Net;

public class InstallsService : IInstallsService {
    private readonly ILoggerService _loggerService;
    private readonly IConfigurationManifestService _configurationManifestService;
    public InstallsService(){
        _loggerService = StaticData.Get<ILoggerService>();
        _configurationManifestService = StaticData.Get<IConfigurationManifestService>();
    }

    public void Install(string ManifestPath){ 
        var installs = GetInstalls();       
        installs.Add(
            new Install {
                AppManifestPath = ManifestPath
            }
        );
        Merge(installs, ManifestPath);
    }

    public void Uninstall(string ManifestPath){
        Merge(GetInstalls().Where(x => x.AppManifestPath != ManifestPath), ManifestPath);
    }

    public void ProcessUninstall(string[] args)
    {
        throw new NotImplementedException();
    }

    public InstallsManifest GetInstallsManifest(string ManifestPath){
        var InstallsManifest = JsonNet.Deserialize<InstallsManifest>(File.ReadAllText(ManifestPath));
        if(InstallsManifest == null){
            _loggerService.PrintFatalError(
                new Exception($"Cannot deserialize installs file at {ManifestPath}"));
        }
        return InstallsManifest;
    }

    public string GetInstallsFile(string WorkingDir){
        var files = Directory.GetFiles(WorkingDir)
            .Where(x => x.EndsWith("installs.json", StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        
        if(files == null){
            _loggerService.PrintFatalError(
                new Exception($"Unable to locate the installs file in {WorkingDir}"));
        }

        if(files.Count == 0){
            return CreateNewInstallsFile(WorkingDir);
        }

        return files.First();
    }

    public List<Install> GetInstalls(){
        return GetInstallsManifest(GetInstallsFile(_configurationManifestService.GetWorkingDirectory()))
                        .Installs
                        .ToList();
    }

    private void Merge(IEnumerable<Install> list, string ManifestPath){
        var manifest = new InstallsManifest(){
            Installs = list,
            ManifestPath = ManifestPath
        };
        
        var file = GetInstallsFile(_configurationManifestService.GetWorkingDirectory());
        using(var fs = new FileStream(file, FileMode.Create, FileAccess.Write)){
            new BinaryFormatter().Serialize(fs, manifest);
            fs.Close();   
        }                 
    }

    private string CreateNewInstallsFile(string WorkingDir){
        if(!Directory.Exists(WorkingDir))
            throw new Exception($"Working directory does not exist {WorkingDir}");

        var path = WorkingDir.EndsWith("\'") 
            ? WorkingDir.Remove(WorkingDir.Length - 1) + "'\'installs.json" 
            : WorkingDir + "'\'installs.json";
        
        using(var fs = File.Create(path)){
            new BinaryFormatter().Serialize(fs, new InstallsManifest());
            fs.Close();
        }
        
        return File.Exists(path) ? path : null;      
    }
}