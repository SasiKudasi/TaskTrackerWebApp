using CSharpFunctionalExtensions;
using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.Models;

namespace Task.Application.Queries.GetTask;

public class GetTaskQueryHandler (ITaskRepository repository): IQueryHandler<GetTaskQuery, Tasks>
{
    public async Task<Result<Tasks>> HandleAsync(GetTaskQuery query, CancellationToken token)
    {
        var task = await repository.GetByIdAsync(query.TaskId);
        if (task == null)
        {
            return Result.Failure<Tasks>("Task not found.");
        }
        else
        {
            return Result.Success(task);
        }
    }
}
