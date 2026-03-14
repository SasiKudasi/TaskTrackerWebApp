namespace Task.Core.Shared.Entities;

public interface IEntity
{
    IReadOnlyCollection<Event> DomainEvents { get; }
    void ClearDomainEvents();
}

public interface IEntity<TId> : IEntity
{
    public TId Id { get; init; }
}
