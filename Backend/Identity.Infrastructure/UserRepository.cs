using Identity.Domain;
using Identity.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAll(CancellationToken token)
    {
        return await _context.Users
             .AsNoTracking()
             .ToListAsync(token);
    }
    public async System.Threading.Tasks.Task AddAsync(User user, CancellationToken token)
    {
        await _context.Users.AddAsync(user, token);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken token)
    {
        return await _context.Users.FirstOrDefaultAsync(x=>x.UserName == userName);
    }
}
