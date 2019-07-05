using System.Linq;
using System;
using System.Collections.Generic;

public class DomainObjectPropertyMapper<T> : IDomainObjectPropertyMapper<T> {
    public string GetMapping(Type type, string propertyName) => GetMappingValue(type, propertyName);

    public Dictionary<string, string> GetMappings(Type type) => Mappings(type);

    public Dictionary<string, string> GetMappings(Type type, string[] keys) => GetMappingsWithProperties(type, keys);

    private Dictionary<string, string> Mappings(Type type){
        if(type == typeof(Install)){
            return new Dictionary<string, string>();
            //add more custom mappings below when needed
        }else{
           var dictionary = new Dictionary<string, string>();
           var props = type.GetProperties().Select(x => x.Name);
           foreach(var prop in props){
               dictionary.Add(prop, prop);
           }
           return dictionary;
        }
    }

    private Dictionary<string, string> GetMappingsWithProperties(Type type, string[] properties){
        var mappingsDictionary = new Dictionary<string, string>();
        if(properties == null || properties.Length == 0) return mappingsDictionary;
        var mappings = Mappings(type);
        foreach(var prop in properties){
            mappingsDictionary.Add(prop, mappings[prop]);
        }
        return mappingsDictionary;
    }

    private string GetMappingValue(Type type, string property){
        return Mappings(type).Where(x => x.Key == property).Select(x => x.Value).FirstOrDefault();
    }
}