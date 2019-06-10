using System.Collections.Generic;

public class RenameOperation : Operation {
    public override (Dictionary<MessageType, string> Messages, int ErrorCount) RunOperation(){
        return (new Dictionary<MessageType, string>(), 0);
    }
    public override Operation GenerateReverseOperation(){
        return this;
    }
}