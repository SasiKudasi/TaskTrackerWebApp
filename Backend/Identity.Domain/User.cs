
using Task.Core.Shared.Entities;

namespace Identity.Domain;

public class User : Entity<Guid>
{
    public override Guid Id { get; init; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }

    private User(Guid id, string userName, string passwordHash, UserRole role)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Role = role;

        // AddDomainEvent
    }


    public static User Create(Guid id, string userName, string passwordHash, UserRole role)
    {
        var user = new User(id, userName, passwordHash, role);
        return user;
    }
}
