using System;
using System.Collections.Generic;

public interface ILoggerService
{
    void PrintFatalError(Exception exception);
    void LogTransactionInformation((Dictionary<MessageType, string> TransactionLog, int ErrorCount) TransactionData);
}