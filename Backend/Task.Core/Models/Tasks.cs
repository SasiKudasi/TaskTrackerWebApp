using Task.Core.DomainEvents;
using Task.Core.Shared.Entities;

namespace Task.Core.Models;
public class Tasks : Entity<Guid>
{
    private Tasks(Guid id, string title, string description, DateTime date)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
        AddDomainEvent(new TaskCreatedEvent(id, title, date));

    }

    public override Guid Id { get; init; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime Date { get; private set; } = DateTime.Now;


    public static Tasks Create(Guid id, string title, string description, DateTime date)
    {
        var task = new Tasks(id, title, description, date);
        return task;
    }
}

