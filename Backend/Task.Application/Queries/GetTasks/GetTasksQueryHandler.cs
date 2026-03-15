
using CSharpFunctionalExtensions;
using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.Models;
using Task.Shared.Contracts;

namespace Task.Application.Queries.GetTasks
{
    public class GetTasksQueryHandler(ITaskRepository repository) : IQueryHandler<GetTasksQuery, List<Tasks>>
    {
        public async Task<Result<List<Tasks>>> HandleAsync(GetTasksQuery query, CancellationToken token)
        {
            var tasks = await repository.GetList(new Specification
            {
                PageNum = query.PageNum,
                PageSize = query.PageSize,
                Sorting = query.Sorting
            });

            if (tasks == null)
            {
                return Result.Failure<List<Tasks>>("No tasks found.");
            }
            else
            {
                return Result.Success(tasks);
            }
        }
    }
}
