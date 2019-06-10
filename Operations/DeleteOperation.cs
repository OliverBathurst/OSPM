using System.Collections.Generic;

public class DeleteOperation : Operation {
    public override (Dictionary<MessageType, string> Messages, int ErrorCount) RunOperation(){
        return (new Dictionary<MessageType, string>(), 0);
    }
    public override Operation GenerateReverseOperation(){
        return this;
    }
}