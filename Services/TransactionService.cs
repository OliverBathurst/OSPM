using System.Linq;

public class TransactionService : ITransactionService {
    private ITransaction Transaction;
    private bool IgnoreWarnings = false;
    public TransactionService(ITransaction TransactionToTransact){
        Transaction = TransactionToTransact;        
    } 
    public TransactionService(ITransaction TransactionToTransact, bool ignoreWarnings){
        Transaction = TransactionToTransact;
        IgnoreWarnings = ignoreWarnings;
    }
    public void Transact(ITransaction TransactionOperation = null){
        if(Transaction == null && TransactionOperation == null)
            return;

        var transactionObj = Transaction == null ? TransactionOperation : Transaction;

        for(var i = 0; i < transactionObj.TransactionOperations?.Count; i++){
            var outcome = transactionObj.TransactionOperations[i].RunOperation();
            ServiceProvider.GetService<ILoggerService>().LogTransactionInformation(outcome);                
            if(outcome.ErrorCount > 0 && !IgnoreWarnings){
                Transact(new Transaction {TransactionOperations = transactionObj.TransactionOperations.GetRange(0, i+1).Select(x => x.GenerateReverseOperation()).ToList()});
                return;
            }
        }
    }
}