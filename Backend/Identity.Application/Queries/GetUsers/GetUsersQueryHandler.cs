using CSharpFunctionalExtensions;
using Identity.Domain;
using Task.Application.Shared;

namespace Identity.Application.Queries.GetUsers;

public class GetUsersQueryHandler (IUserRepository repository) : IQueryHandler<GetUsersQuery, List<User>>
{
    public async Task<Result<List<User>>> HandleAsync(GetUsersQuery query, CancellationToken token)
    {
        return await repository.GetAll(token);
    }
}
