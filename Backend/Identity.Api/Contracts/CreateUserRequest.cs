using Identity.Domain;

namespace Identity.Api.Contracts;

public record CreateUserRequest(string UserName, string Password, UserRole Role);
