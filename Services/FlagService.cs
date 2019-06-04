

using System.Collections.Generic;

public class FlagService {
    public FlagService(){}

    public List<string> GetUpdateFlags() => GetGlobalFlags();

    public List<string> GetDeleteFlags() =>GetGlobalFlags();   

    private List<string> GetGlobalFlags() => new List<string>{ "-ignorewarnings" };
}