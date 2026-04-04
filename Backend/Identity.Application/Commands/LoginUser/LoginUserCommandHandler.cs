using CSharpFunctionalExtensions;
using Identity.Domain;
using Identity.Infrastructure.JwtUtils;
using Identity.Infrastructure.Utils;
using Task.Application.Shared;

namespace Identity.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler(IUserRepository repository, JwtProvider jwtProvider) : ICommandHandler<LoginUserCommand>
    {
        public async Task<Result<(bool isSucces, string msg)>> HandleAsync(LoginUserCommand command, CancellationToken token)
        {
            var user = await repository.GetByUserNameAsync(command.UserName, token);
            if(user is null)
            {
                return Result.Failure<(bool, string)>("User not found");
            }

            if (PasswordHasher.VerifyPassword(command.Password, user.PasswordHash))
            {
                var jwtToken = jwtProvider.GenerateToken(user);
                return Result.Success((true, jwtToken));
            }
            else
            {
                return Result.Failure<(bool, string)>("Invalid password");
            }
        }
    }
}
