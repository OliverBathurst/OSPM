using System.Linq;

public class TransactionService : ITransactionService {
    private readonly ITransaction Transaction;
    private readonly ILoggerService _loggerService;
    private readonly bool IgnoreWarnings;
    
    public TransactionService(ITransaction TransactionToTransact){
        Transaction = TransactionToTransact;        
        _loggerService = StaticData.Get<ILoggerService>();
    } 
    public TransactionService(ITransaction TransactionToTransact, bool ignoreWarnings){
        Transaction = TransactionToTransact;
        IgnoreWarnings = ignoreWarnings;
        _loggerService = StaticData.Get<ILoggerService>();
    }
    public void Transact(ITransaction TransactionOperation = null){
        if(Transaction == null && TransactionOperation == null)
            return;

        var transactionObj = Transaction == null ? TransactionOperation : Transaction;

        for(var i = 0; i < transactionObj.TransactionOperations?.Count; i++){
            var outcome = transactionObj.TransactionOperations[i].RunOperation();
            _loggerService.LogTransactionInformation(outcome);                
            if(outcome.ErrorCount > 0 && !IgnoreWarnings){//rollback
                Transact(new Transaction {TransactionOperations = transactionObj.TransactionOperations.GetRange(0, i+1).Select(x => x.GenerateReverseOperation()).ToList()});
                return;
            }
        }
    }
}