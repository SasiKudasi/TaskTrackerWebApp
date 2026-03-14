using Task.Core.Shared.Entities;

namespace Task.EventBus.Abstractions;

public interface IEventHandler<TEvent> where TEvent : Event
{
    System.Threading.Tasks.Task Handle(TEvent @event);
}
