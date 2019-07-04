using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Json.Net;

public class InstallsService : IInstallsService {
    private readonly Context _context;
    public InstallsService(Context context){
        _context = context;
    }

    public void Install(string ManifestPath){
        AddInstall(ManifestPath);
    }

    public void Uninstall(string ManifestPath){                
        AddUninstall(ManifestPath);
    }

    public InstallsManifest GetInstallsManifest(string ManifestPath){
        var InstallsManifest = JsonNet.Deserialize<InstallsManifest>(File.ReadAllText(ManifestPath));
        if(InstallsManifest == null){
            _context.LoggerService.PrintFatalError(
                new Exception($"Cannot deserialize installs file at {ManifestPath}"));
        }
        return InstallsManifest;
    }

    public string GetInstallsFile(string WorkingDir){
        var files = Directory.GetFiles(WorkingDir)
            .Where(x => x.EndsWith("installs.json", StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        
        if(files == null || files.Count != 1){
            _context.LoggerService.PrintFatalError(
                new Exception($"Unable to locate the installs file in {WorkingDir}"));
        }
        return files.First();
    }

    public List<Install> GetInstalls(){
        return GetInstallsManifest(GetInstallsFile(_context.ConfigurationManifestService.GetWorkingDirectory()))
                        .Installs
                        .ToList();
    }

    private void AddInstall(string ManifestPath){ 
        var installs = GetInstalls();       
        installs.Add(
            new Install{
                AppManifestPath = ManifestPath
            }
        );
        Merge(installs, ManifestPath);
    }

    private void AddUninstall(string ManifestPath){
        Merge(GetInstalls().Where(x => x.AppManifestPath != ManifestPath), ManifestPath);
    }

    private void Merge(IEnumerable<Install> list, string ManifestPath){
        var manifest = new InstallsManifest(){
            Installs = list,
            ManifestPath = ManifestPath
        };
        
        var file = GetInstallsFile(_context.ConfigurationManifestService.GetWorkingDirectory());
        var stream = new FileStream(file, FileMode.Create, FileAccess.Write);
        new BinaryFormatter().Serialize(stream, manifest);
        stream.Close();            
    }
}