using System;
public abstract class DomainObjectKey {
    private Guid InternalIdentifier;
    public DomainObjectKey() => InternalIdentifier = Guid.NewGuid();
    public Guid Key { get => InternalIdentifier; }

    public override string ToString() => $"{GetType()} #{InternalIdentifier}";
}