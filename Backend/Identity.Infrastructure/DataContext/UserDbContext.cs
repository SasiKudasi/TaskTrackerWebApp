using Identity.Domain;
using Identity.Infrastructure.Configure;
using Microsoft.EntityFrameworkCore;
using Task.Core.Shared.Entities;

namespace Identity.Infrastructure.DataContext;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfiguration(new UserConfigure());
        base.OnModelCreating(modelBuilder);
    }
}
