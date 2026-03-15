namespace Task.Application.Shared;

public interface ICommandHandler<TCommand> 
    where TCommand : ICommand
{
    System.Threading.Tasks.Task HandleAsync(TCommand command, CancellationToken token);
}
