using System.Linq;
using System.Collections.Generic;

public class OperationValidatorService : IValidator<Operation>
{
    public Dictionary<MessageType, string> Validate(Operation ObjectToValidate)
    {


        //TODO: CHANGE ALL DICTIONARY OBJECTS IN THIS PROJECT TO LIST<KEYVALUEPAIR<MESSAGETYPE,STRING>>


        var Errors = new Dictionary<MessageType, string>();
        if(ObjectToValidate == null)
            Errors.Add(MessageType.Error, "Operation is null");

        GenericValidation(ObjectToValidate);

        var validationErrors = new Dictionary<MessageType, string>();
        switch (ObjectToValidate.OperationType){
            case OperationType.Move:
                validationErrors = ValidateMoveOperation(ObjectToValidate);                
                break;
            case OperationType.Rename:
                validationErrors = ValidateRenameOperation(ObjectToValidate);
                break;
            default:
                throw new System.Exception($"Illegal or missing operation type, operation number: {ObjectToValidate.OperationNumber}, manifest: {ObjectToValidate.Manifest.ManifestName}");
        }
        
        foreach(var validationError in validationErrors)
            Errors.Add(validationError.Key, validationError.Value);

        return Errors;    
    }

    //All operations need a filepath so we can call this before specific validation
    private Dictionary<MessageType, string> GenericValidation(Operation ObjectToValidate){
        if(ObjectToValidate.FilePath == null){
            //throw error
        }
        return new Dictionary<MessageType, string>();
    }

    private Dictionary<MessageType, string> ValidateMoveOperation(Operation ObjectToValidate){
        if(ObjectToValidate.Destination == null){

        }
        return new Dictionary<MessageType, string>();
    }

    private Dictionary<MessageType, string> ValidateRenameOperation(Operation ObjectToValidate){
        if(ObjectToValidate.RenameString == null){

        }
        return new Dictionary<MessageType, string>();
    }
}