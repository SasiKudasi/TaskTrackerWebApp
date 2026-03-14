using Task.Core.Shared.Entities;

namespace Task.EventBus.Abstractions;

public interface IEventDispatcher
{
    System.Threading.Tasks.Task Dispatch(IEnumerable<Event> events);
}
