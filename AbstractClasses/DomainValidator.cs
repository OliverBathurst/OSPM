using System;
using System.Collections.Generic;

public abstract class DomainValidator<T> {
    Dictionary<string, object> Validate(T ObjectToValidate, string propertyName){
        return ValidateAndReturnValues(ObjectToValidate, new string[] {propertyName} );
    }
    Dictionary<string, object> ValidateAndReturnValues(T ObjectToValidate, string[] propertyNames){
        if(ObjectToValidate == null){
            throw new Exception("Object being validated is null");
        }
        var dictionary = new Dictionary<string, object>();
        foreach(var prop in propertyNames){
            var value = ObjectToValidate.GetType()
                        .GetProperty(prop)
                        .GetValue(ObjectToValidate, null);

            if(value == null){
                throw new Exception($"No value for property: {prop} found on object being validated");
            }
            dictionary.Add(prop, value);
        }        
        return dictionary;
    }

    void Validate(T ObjectToValidate, string[] propertyNames){
        if(ObjectToValidate == null){
            throw new Exception("Object being validated is null");
        }
        //todo
    }

    void ValidateAndThen(T ObjectToValidate, string[] propertyNames, Action action){
        Validate(ObjectToValidate, propertyNames);
        action();
    }
}