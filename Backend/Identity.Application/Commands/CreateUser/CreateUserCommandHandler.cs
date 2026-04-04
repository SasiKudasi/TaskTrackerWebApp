using CSharpFunctionalExtensions;
using Identity.Domain;
using Identity.Infrastructure.Utils;
using Task.Application.Shared;

namespace Identity.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IUserUnitOfWork uof) : ICommandHandler<CreateUserCommand>
{
    public async Task<Result<(bool isSucces, string msg)>> HandleAsync(CreateUserCommand command, CancellationToken token)
    {
        try
        {
            var pswHash = PasswordHasher.HashPassword(command.Password);
            var user = User.Create(Guid.NewGuid(), command.UserName, pswHash, command.Role);
            await userRepository.AddAsync(user, token);
            await uof.CommitAsync(token);
            return Result.Success<(bool isSucces, string msg)>((true, "User created successfully."));

        }
        catch (Exception ex)
        {
            return Result.Failure<(bool isSucces, string msg)>($"Failed to create user: {ex.Message}");
        }
    }
}
