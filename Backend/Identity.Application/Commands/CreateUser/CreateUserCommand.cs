using Identity.Domain;
using Task.Application.Shared;

namespace Identity.Application.Commands.CreateUser;

public record CreateUserCommand(string UserName, string Password, UserRole Role) : ICommand;

