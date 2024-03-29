using System;
using Microsoft.Extensions.DependencyInjection;

public static class StaticData {
    private static IServiceProvider _serviceProvider;

    public static void Initialize() => RegisterServices();

    public static void Dispose() => DisposeServices();     

    public static T Get<T>(){
        return _serviceProvider.GetService<T>();
    }

    public static object GetService(Type serviceType) => _serviceProvider.GetService(serviceType);

    private static void RegisterServices()
    {
        var collection = new ServiceCollection()
        .AddSingleton<IFileValidatorService, FileValidatorService>()
        .AddSingleton<IConfigurationManifestService, ConfigurationManifestService>()
        .AddSingleton<IConfigurationManifestValidatorService, ConfigurationManifestValidatorService>()
        .AddSingleton<IFileDownloaderService, FileDownloaderService>()
        .AddSingleton<IFileValidatorService, FileValidatorService>()
        .AddSingleton<ILoggerService, LoggerService>()
        .AddSingleton<IConfigurationFileProcessorService, ConfigurationFileProcessorService>();
        _serviceProvider = collection.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if(_serviceProvider == null)
        {
            return;
        }
        if (_serviceProvider is IDisposable)
        {
            ((IDisposable)_serviceProvider).Dispose();
        }
    }
}