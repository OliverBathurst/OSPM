using System.Linq;
using System;
using System.Collections.Generic;

public class DomainObjectPropertyMapper<T> : IDomainObjectPropertyMapper<T> {
    public string GetMapping(string propertyName) => GetMappingValue(propertyName);

    public Dictionary<string, string> GetMappings() => Mappings();

    public Dictionary<string, string> GetMappings(string[] keys) => GetMappingsWithProperties(keys);

    private Dictionary<string, string> Mappings(){                
        //add custom mappings here when needed
        var mappings = typeof(T).GetProperties().Select(x => x.Name);
        return mappings.ToDictionary(prop => prop, prop => prop);       
    }

    private Dictionary<string, string> GetMappingsWithProperties(string[] properties){
        if(properties == null || properties.Length == 0) return new Dictionary<string, string>();
        var mappings = Mappings();

        return properties.ToDictionary(prop => prop, prop => mappings[prop]);
    }

    private string GetMappingValue(string property){
        return Mappings().Where(x => x.Key == property).Select(x => x.Value).FirstOrDefault();
    }
}