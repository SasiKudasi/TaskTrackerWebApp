
using Task.Core.Shared.Entities;

namespace Task.Core.DomainEvents;

public class TaskCreatedEvent : Event
{
    public Guid TaskId { get; init; }
    public string TaskName { get; init; }

    public TaskCreatedEvent(Guid taskId, string taskName, DateTime creationDate) : base (creationDate)
    {
        TaskId = taskId;
        TaskName = taskName;
    }
}
