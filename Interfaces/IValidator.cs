using System.Collections.Generic;

public interface IValidator<T> {
    Dictionary<MessageType, string> Validate(T ObjectToValidate);
}