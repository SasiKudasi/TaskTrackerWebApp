using Task.Application.Shared;

namespace Task.Application.Queries.GetTask;

public record GetTaskQuery(Guid TaskId) : IQuery;
