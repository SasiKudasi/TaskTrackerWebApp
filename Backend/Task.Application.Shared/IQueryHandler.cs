using CSharpFunctionalExtensions;

namespace Task.Application.Shared;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery       
{
    Task<Result<TResult>> HandleAsync(TQuery query);
}
