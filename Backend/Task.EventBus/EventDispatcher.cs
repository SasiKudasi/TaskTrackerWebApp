using Task.Core.Shared.Entities;
using Task.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Task.EventBus;

public class EventDispatcher(IServiceProvider serviceProvider) : IEventDispatcher
{
    public async System.Threading.Tasks.Task Dispatch(IEnumerable<Event> events)
    {
        foreach (var @event in events)
        {
            var eventType = @event.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
            var handlers = serviceProvider.GetServices(handlerType);
            foreach (var handler in handlers)
            {
                var method = handlerType.GetMethod("Handle");
                if (method != null)
                {
                    method.Invoke(handler, new object[] { @event });
                }
            }
        }
    }
}
