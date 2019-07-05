using System;
using System.Collections.Generic;
using System.Linq;

public static class Repository {    
    static Dictionary<Type, object> cache = new Dictionary<Type, object>();
    public static T Get<T>() => 
        (T) cache.Where(x => x.Key.GetType().IsAssignableFrom(typeof(T)) 
                && !x.Key.GetType().IsAbstract
                && !x.Key.GetType().IsInterface)
                .First()
                .Value;    

    public static void Put<T>(T item){
        cache.Add(typeof(T), item);
    }
}