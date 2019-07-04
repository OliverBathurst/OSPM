public class Context {
    private UpdateService _updateService;
    private TransactionService _transactionService;
    private OperationValidatorService _operationValidatorService;
    private FileValidatorService _fileValidatorService;
    private FileDownloaderService _fileDownloaderService;
    private DeleteService _deleteService;
    private ConfigurationManifestService _configurationManifestService;
    private ConfigurationManifestValidatorService _configurationManifestValidatorService;
    private ConfigFileProcessorService _configurationFileProcessorService;
    private LoggerService _loggerService;
    public Context() => InitialiseContext();
    public TransactionService TransactionService(Context context, ITransaction TransactionToTransact = null, bool ignoreWarnings = false) => new TransactionService(this, TransactionToTransact, ignoreWarnings);
    public UpdateService UpdateService => new UpdateService(this);
    public DeleteService DeleteService => new DeleteService(this);
    public OperationValidatorService OperationValidatorService => _operationValidatorService;
    public FileValidatorService FileValidatorService => _fileValidatorService; 
    public FileDownloaderService FileDownloaderService => _fileDownloaderService;
    public ConfigurationManifestService ConfigurationManifestService => _configurationManifestService;
    public ConfigurationManifestValidatorService ConfigurationManifestValidatorService => _configurationManifestValidatorService;
    public ConfigFileProcessorService ConfigurationFileProcessorService => _configurationFileProcessorService;
    public LoggerService LoggerService => _loggerService;
    private void InitialiseContext(){
        _operationValidatorService = new OperationValidatorService();
        _fileValidatorService = new FileValidatorService(this);
        _fileDownloaderService = new FileDownloaderService();
        _configurationManifestService = new ConfigurationManifestService();
        _configurationManifestValidatorService = new ConfigurationManifestValidatorService();
        _configurationFileProcessorService = new ConfigFileProcessorService();
        _loggerService = new LoggerService();
    }
}