using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.Models;
using CSharpFunctionalExtensions;
namespace Task.Application.Commands.CreateTask;

public class CreateTaskCommandHandler(
    ITaskRepository repository,
    ITaskUnitOfWork uof
    ) : ICommandHandler<CreateTaskCommand>
{
    public async Task<Result<(bool isSucces, string msg)>> HandleAsync(CreateTaskCommand command, CancellationToken token)
    {
        try
        {
            var task = Tasks.Create(
                command.TaskID,
                command.Title,
                command.Description,
                DateTime.UtcNow);
            await repository.Create(task);
            await uof.CommitAsync(token);
            return Result.Success((true, "Task created successfully"));
        }
        catch (Exception ex)
        {
            return Result.Failure<(bool isSucces, string msg)>($"Failed to create task: {ex.Message}");
        }


    }
}
