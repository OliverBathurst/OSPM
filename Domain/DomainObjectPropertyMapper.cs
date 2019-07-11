using System.Linq;
using System;
using System.Collections.Generic;

public class DomainObjectPropertyMapper<T> : IDomainObjectPropertyMapper<T> {
    public string GetMapping(Type type, string propertyName) => GetMappingValue(type, propertyName);

    public Dictionary<string, string> GetMappings(Type type) => Mappings(type);

    public Dictionary<string, string> GetMappings(Type type, string[] keys) => GetMappingsWithProperties(type, keys);

    private Dictionary<string, string> Mappings(Type type){
        //add custom mappings here when needed
        var mappings = type.GetProperties().Select(x => x.Name);
        return mappings.ToDictionary(prop => prop, prop => prop);       
    }

    private Dictionary<string, string> GetMappingsWithProperties(Type type, string[] properties){
        if(properties == null || properties.Length == 0) return new Dictionary<string, string>();
        var mappings = Mappings(type);

        return properties.ToDictionary(prop => prop, prop => mappings[prop]);
    }

    private string GetMappingValue(Type type, string property){
        return Mappings(type).Where(x => x.Key == property).Select(x => x.Value).FirstOrDefault();
    }
}