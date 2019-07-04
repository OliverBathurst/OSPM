using System;
using System.Collections.Generic;

public class Transaction : ITransaction
{
    private Guid TransactionIdentifier;
    private List<Operation> Operations;
    public Transaction() => TransactionIdentifier = Guid.NewGuid();
    ~Transaction() => Console.WriteLine($"Transaction {TransactionIdentifier} has been terminated");
    public Guid TransactionID { get => TransactionIdentifier; }
    public List<Operation> TransactionOperations { get => Operations; set => Operations = value; }
}