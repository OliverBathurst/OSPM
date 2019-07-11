public interface IInstallsService
{
    void Install(string ManifestPath);
    void ProcessUninstall(string[] args);
}