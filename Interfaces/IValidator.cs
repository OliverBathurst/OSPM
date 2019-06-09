using System.Collections.Generic;

public interface IValidator<T> {
    List<KeyValuePair<MessageType, string>> Validate(T ObjectToValidate);
}