using System;
using System.Collections.Generic;

public interface ITransaction {
    Guid TransactionID { get; }
    List<Operation> TransactionOperations { get; set; }    
}