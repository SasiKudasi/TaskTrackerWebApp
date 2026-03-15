using Microsoft.Extensions.Logging;
using Task.Core.DomainEvents;
using Task.EventBus.Abstractions;

namespace Task.Application.EventHandlers;

public class TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger) : IEventHandler<TaskCreatedEvent>
{
    public async System.Threading.Tasks.Task Handle(TaskCreatedEvent @event)
    {
        logger.LogInformation("Handling TaskCreatedEvent: TaskId={TaskId}, TaskName={TaskName}, Description={Description}",
            @event.TaskId, @event.TaskName, @event.Description);
    }
}
