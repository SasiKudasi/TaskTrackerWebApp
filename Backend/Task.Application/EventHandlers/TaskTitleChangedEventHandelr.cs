using Microsoft.Extensions.Logging;
using Task.Core.DomainEvents;
using Task.EventBus.Abstractions;

namespace Task.Application.EventHandlers;

public class TaskTitleChangedEventHandelr(ILogger<TaskTitleChangedEventHandelr> logger) : IEventHandler<TaskTitleChangedEvent>
{
    public async System.Threading.Tasks.Task Handle(TaskTitleChangedEvent @event)
    {
        logger.LogInformation("TaskTitleChangedEventHandelr received TaskTitleChangedEvent: TaskId={TaskId}, TaskName={TaskName}", @event.TaskId, @event.TaskName);
    }
}
