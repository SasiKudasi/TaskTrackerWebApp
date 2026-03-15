using Task.Application.Shared;

namespace Task.Application.Queries.GetTasks;

public record GetTasksQuery(int PageSize, int PageNum, string Sorting) : IQuery;