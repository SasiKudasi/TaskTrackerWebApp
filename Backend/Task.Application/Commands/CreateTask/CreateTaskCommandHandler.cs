using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.Models;

namespace Task.Application.Commands.CreateTask;

public class CreateTaskCommandHandler(
    ITaskRepository repository,
    ITaskUnitOfWork uof
    ) : ICommandHandler<CreateTaskCommand>
{
    public async System.Threading.Tasks.Task HandleAsync(CreateTaskCommand command, CancellationToken token)
    {
        var task = Tasks.Create(
            command.TaskID,
            command.Title,
            command.Description,
            DateTime.UtcNow
        );

        await repository.Create(task);
        await uof.CommitAsync(token);
    }
}
