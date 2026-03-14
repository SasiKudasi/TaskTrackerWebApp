namespace Task.Core.Shared.Entities;

public abstract class Entity : IEntity
{
    private List<Event>? _domainEvents;

    public IReadOnlyCollection<Event> DomainEvents =>
        _domainEvents is null ? Array.Empty<Event>() : _domainEvents.AsReadOnly();

    protected void AddDomainEvent(Event @eventItem)
    {
        _domainEvents ??= new List<Event>();
        _domainEvents.Add(@eventItem);
    }
    public void ClearDomainEvents() => _domainEvents?.Clear();

}
public abstract class Entity<TId> : Entity, IEntity<TId>
{
    public abstract TId Id { get; init; }
}
