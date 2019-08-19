using System;
using System.Collections.Generic;

public class DomainObject<T> : DomainObjectKey, IDomainObject<T> {
    private static IList<PropertyChangeEventSuspender> PropertyChangeEventSuspenders;
    private delegate void PropertyChangedCallback();

    
    public override string ToString() => $"{GetType().ToString()} #{Key}";

    public string ToLogString(){
        return "todo";
    }
    
    public IDisposable SuspendPropertyChangeEvents(){      
        if(PropertyChangeEventSuspenders == null){
            PropertyChangeEventSuspenders = new List<PropertyChangeEventSuspender>();
        }

        return new PropertyChangeEventSuspender(PropertyChangeEventSuspenders);
    }

    private void PropertyChanged(PropertyChangedCallback Callback){
        if(!IsSuspended){
            Callback();
        }
    }

    protected bool IsSuspended {
        get {
            return PropertyChangeEventSuspenders.Count > 0;
        }
    }

    protected void ForceClearEventSuspenders() => PropertyChangeEventSuspenders.Clear();

    private class PropertyChangeEventSuspender : IDisposable
    {
        private IList<PropertyChangeEventSuspender> Suspenders;
        public PropertyChangeEventSuspender(IList<PropertyChangeEventSuspender> ExistingSuspenders){
            Suspenders = ExistingSuspenders;
        }

        public void Dispose() {
            Suspenders.Remove(this);
        }
    }
}