using System;
using System.Collections.Generic;

public class OperationValidatorService : DomainValidator<Operation>, IValidator<Operation>, IOperationValidatorService {
    public List<KeyValuePair<MessageType, string>> Validate(Operation ObjectToValidate)
    {
        var Errors = new List<KeyValuePair<MessageType, string>>();
        if(ObjectToValidate == null)
            Errors.Add(new KeyValuePair<MessageType, string>(MessageType.Error, "Operation is null"));

        GenericValidation(ObjectToValidate);

        var validationErrors = new List<KeyValuePair<MessageType, string>>();
        switch (ObjectToValidate.OperationType){
            case OperationType.Move:
                validationErrors = ValidateMoveOperation(ObjectToValidate);                
                break;
            case OperationType.Rename:
                validationErrors = ValidateRenameOperation(ObjectToValidate);
                break;
            default:
                throw new Exception($"Illegal or missing operation type, operation number: {ObjectToValidate.OperationNumber}, manifest: {ObjectToValidate.Manifest.ManifestPath}");
        }
        
        foreach(var validationError in validationErrors)
            Errors.Add(new KeyValuePair<MessageType, string>(validationError.Key, validationError.Value));

        return Errors;    
    }

    //All operations need a filepath so we can check this before specific validation
    private List<KeyValuePair<MessageType, string>> GenericValidation(Operation ObjectToValidate){
        if(ObjectToValidate.FilePaths == null){
            //throw error
        }
        return new List<KeyValuePair<MessageType, string>>();
    }

    private List<KeyValuePair<MessageType, string>> ValidateMoveOperation(Operation ObjectToValidate){
        if(ObjectToValidate.Destination == null){

        }
        return new List<KeyValuePair<MessageType, string>>();
    }

    private List<KeyValuePair<MessageType, string>> ValidateRenameOperation(Operation ObjectToValidate){
        if(ObjectToValidate.RenameString == null){

        }
        return new List<KeyValuePair<MessageType, string>>();
    }
}