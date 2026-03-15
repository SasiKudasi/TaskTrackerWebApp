using CSharpFunctionalExtensions;
using Task.Application.Shared;
using Task.Core.Abstraction;

namespace Task.Application.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler(
        ITaskRepository repository,
        ITaskUnitOfWork uof) : ICommandHandler<DeleteTaskCommand>
    {
        public async Task<Result<(bool isSucces, string msg)>> HandleAsync(DeleteTaskCommand command, CancellationToken token)
        {
            var task = await repository.GetByIdAsync(command.TaskId);
            if (task == null)
            {
                return Result.Failure<(bool isSucces, string msg)>($"Task with id {command.TaskId} not found.");
            }
            try
            {
                repository.Delete(task);
                await uof.CommitAsync(token);
                return Result.Success<(bool isSucces, string msg)>((true, $"Task with id {command.TaskId} deleted successfully."));
            }
            catch (Exception ex)
            {
                return Result.Failure<(bool isSucces, string msg)>($"An error occurred while deleting the task: {ex.Message}");
            }
        }
    }
}
