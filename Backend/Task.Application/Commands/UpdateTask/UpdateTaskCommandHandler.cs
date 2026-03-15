using Task.Application.Shared;
using Task.Core.Abstraction;
using CSharpFunctionalExtensions;
namespace Task.Application.Commands.UpdateTask;

public class UpdateTaskCommandHandler(
    ITaskRepository repository,
    ITaskUnitOfWork uof) : ICommandHandler<UpdateTaskCommand>
{
    public async Task<Result<(bool isSucces, string msg)>> HandleAsync(UpdateTaskCommand command, CancellationToken token)
    {
        var task = await repository.GetByIdAsync(command.TaskId);
        if (task is null)
            return Result.Failure<(bool, string)>("Task not found");

        if (!task.Title.Equals(command.Title))
        {
            task.ChangeTitle(command.Title);
        }

        if (!task.Description.Equals(command.Description))
        {
            task.ChangeDescription(command.Description);
        }

        try
        {
            await repository.Update(task);
            await uof.CommitAsync(token);
            return Result.Success((true, "Task updated successfully"));

        }
        catch (Exception ex)
        {
            return Result.Failure<(bool, string)>($"An error occurred while updating the task: {ex.Message}");
        }

    }
}
