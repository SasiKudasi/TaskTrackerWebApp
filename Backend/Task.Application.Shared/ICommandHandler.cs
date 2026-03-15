using CSharpFunctionalExtensions;

namespace Task.Application.Shared;

public interface ICommandHandler<TCommand> 
    where TCommand : ICommand
{
   public Task<Result<(bool isSucces, string msg)>> HandleAsync(TCommand command, CancellationToken token);
}
