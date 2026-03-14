
using Task.Core.Shared.Entities;

namespace Task.Core.DomainEvents;

public class TaskDescriptionChangedEvent : Event
{
    public Guid TaskId { get; init; }
    public string Description { get; init; }

    public TaskDescriptionChangedEvent(Guid taskId, string description, DateTime creationDate) : base (creationDate)
    {
        TaskId = taskId;
        Description = description;
    }
}
