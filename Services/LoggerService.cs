using System;
using System.Linq;
using System.Collections.Generic;

public class LoggerService : ILoggerService {
    public LoggerService(){}

    public void LogTransactionInformation((Dictionary<MessageType, string> TransactionLog, int ErrorCount) TransactionData){
        if(TransactionData.ErrorCount > 0){
            PrintError($"An error has occurred: {TransactionData.TransactionLog.First(x => x.Key == MessageType.Error).Value}");
        }else{
            foreach(var pair in TransactionData.TransactionLog)
                Console.WriteLine($"INFO: {pair.Value}");    
        }   
    }

    public void PrintFatalError(Exception exception){
        Console.ForegroundColor = ConsoleColor.Red;        
        Console.WriteLine(exception.Message);
        throw exception;             
    }

    private void PrintError(string errorText){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorText);
        Console.ResetColor();
    }
}