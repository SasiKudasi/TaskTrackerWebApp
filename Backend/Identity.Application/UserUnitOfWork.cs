using Identity.Domain;
using Identity.Infrastructure.DataContext;
using Task.Core.Shared.Entities;
using Task.EventBus.Abstractions;

namespace Task.Application;

public class UserUnitOfWork (UserDbContext context, IEventDispatcher dispatcher) : IUserUnitOfWork
{
    public async System.Threading.Tasks.Task CommitAsync(CancellationToken ct)
    {
        var entities = context.ChangeTracker
           .Entries<Entity>()
           .Select(x => x.Entity)
           .Where(x => x.DomainEvents.Any())
           .ToList();
        
        var events = entities
           .SelectMany(x => x.DomainEvents)
           .ToList();
        
        await dispatcher.Dispatch(events);
        
        entities.ForEach(e => e.ClearDomainEvents());
        
        await context.SaveChangesAsync(ct);

    }
}
