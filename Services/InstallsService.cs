using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Json.Net;

public class InstallsService : IInstallsService {
    public InstallsService(){}

    public void Install(string ManifestPath){
        ProcessInstall(ManifestPath);
    }

    public void Uninstall(string ManifestPath){                
        ProcessUninstall(ManifestPath);
    }

    public InstallsManifest GetInstallsManifest(string ManifestPath){
        var InstallsManifest = JsonNet.Deserialize<InstallsManifest>(File.ReadAllText(ManifestPath));
        if(InstallsManifest == null){
            ServiceProvider.GetService<ILoggerService>().PrintFatalError(
                new Exception($"Cannot deserialize installs file at {ManifestPath}"));
        }
        return InstallsManifest;
    }

    public string GetInstallsFile(string WorkingDir){
        var files = Directory.GetFiles(WorkingDir)
            .Where(x => x.EndsWith("installs.json", StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        
        if(files == null){
            ServiceProvider.GetService<ILoggerService>().PrintFatalError(
                new Exception($"Unable to locate the installs file in {WorkingDir}"));
        }

        if(files.Count == 0){
            return CreateNewInstallsFile(WorkingDir);
        }

        return files.First();
    }

    public List<Install> GetInstalls(){
        return GetInstallsManifest(GetInstallsFile(ServiceProvider.GetService<IConfigurationManifestService>().GetWorkingDirectory()))
                        .Installs
                        .ToList();
    }

    private void ProcessInstall(string ManifestPath){ 
        var installs = GetInstalls();       
        installs.Add(
            new Install {
                AppManifestPath = ManifestPath
            }
        );
        Merge(installs, ManifestPath);
    }

    private void ProcessUninstall(string ManifestPath){
        Merge(GetInstalls().Where(x => x.AppManifestPath != ManifestPath), ManifestPath);
    }

    private void Merge(IEnumerable<Install> list, string ManifestPath){
        var manifest = new InstallsManifest(){
            Installs = list,
            ManifestPath = ManifestPath
        };
        
        var file = GetInstallsFile(ServiceProvider.GetService<IConfigurationManifestService>().GetWorkingDirectory());
        using(var fs = new FileStream(file, FileMode.Create, FileAccess.Write)){
            new BinaryFormatter().Serialize(fs, manifest);
            fs.Close();   
        }                 
    }

    private string CreateNewInstallsFile(string WorkingDir){
        var path = WorkingDir + "'\'installs.json";
        if(Directory.Exists(WorkingDir)){
            using(var fs = File.Create(path)){
                new BinaryFormatter().Serialize(fs, new InstallsManifest());
                fs.Close();
            }
        }
        return File.Exists(path) ? path : null;      
    }
}