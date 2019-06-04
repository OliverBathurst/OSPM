using System;
using System.Linq;
using System.Collections.Generic;

public class LoggerService {
    public LoggerService(){}

    public void LogTransactionInformation((Dictionary<MessageType, string> TransactionLog, int ErrorCount) TransactionData){
        if(TransactionData.ErrorCount > 0){
            PrintError($"An error has occurred: {TransactionData.TransactionLog.First(x => x.Key == MessageType.Error).Value}");
        }else{
            foreach(var pair in TransactionData.TransactionLog)
                Console.WriteLine($"INFO: {pair.Value}");    
        }   
    }

    private void PrintError(string errorText){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorText);
        Console.ResetColor();
    }
}