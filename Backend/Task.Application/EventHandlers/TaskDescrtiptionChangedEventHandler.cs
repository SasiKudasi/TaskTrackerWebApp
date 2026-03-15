using Microsoft.Extensions.Logging;
using Task.Core.DomainEvents;
using Task.EventBus.Abstractions;

namespace Task.Application.EventHandlers;

public class TaskDescrtiptionChangedEventHandler(ILogger<TaskDescrtiptionChangedEventHandler> logger) : IEventHandler<TaskDescriptionChangedEvent>
{
    public System.Threading.Tasks.Task Handle(TaskDescriptionChangedEvent @event)
    {
        logger.LogInformation("Handling TaskDescriptionChangedEvent: TaskId={TaskId}, Description={OldDescription}",
            @event.TaskId, @event.Description);
        return System.Threading.Tasks.Task.CompletedTask;
    }
}
