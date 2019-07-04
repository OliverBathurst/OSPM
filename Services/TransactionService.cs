using System.Linq;

public class TransactionService : ITransactionService {
    private ITransaction Transaction;
    private Context _context;
    private bool IgnoreWarnings = false;
    public TransactionService(Context context, ITransaction TransactionToTransact){
        _context = context;
        Transaction = TransactionToTransact;        
    } 
    public TransactionService(Context context, ITransaction TransactionToTransact, bool ignoreWarnings){
        _context = context;
        Transaction = TransactionToTransact;
        IgnoreWarnings = ignoreWarnings;
    }
    public void Transact(ITransaction TransactionOperation = null){
        if(Transaction == null && TransactionOperation == null)
            return;

        var transactionObj = Transaction == null ? TransactionOperation : Transaction;

        for(var i = 0; i < transactionObj.TransactionOperations?.Count; i++){
            var outcome = transactionObj.TransactionOperations[i].RunOperation();
            _context.LoggerService.LogTransactionInformation(outcome);                
            if(outcome.ErrorCount > 0 && !IgnoreWarnings){
                Transact(new Transaction {TransactionOperations = transactionObj.TransactionOperations.GetRange(0, i+1).Select(x => x.GenerateReverseOperation()).ToList()});
                return;
            }
        }
    }
}