namespace Identity.Domain;

public interface IUserRepository
{
    System.Threading.Tasks.Task AddAsync(User user, CancellationToken token);
    void Remove(User user);
    Task<List<User>> GetAll(CancellationToken token);
    Task<User?> GetByUserNameAsync(string userName, CancellationToken token);
}
