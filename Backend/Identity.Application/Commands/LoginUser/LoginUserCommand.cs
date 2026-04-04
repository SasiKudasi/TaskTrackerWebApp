using Task.Application.Shared;

namespace Identity.Application.Commands.LoginUser
{
    public record LoginUserCommand(string UserName, string Password) : ICommand;
}
