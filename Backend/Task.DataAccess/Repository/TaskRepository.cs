using Microsoft.EntityFrameworkCore;
using Task.Core.Abstraction;
using Task.Core.Models;
namespace Task.DataAccess.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _dbContext;
    public TaskRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tasks>> Get()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async System.Threading.Tasks.Task GetByIdAsync(Guid id)
    {
        await _dbContext.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async System.Threading.Tasks.Task Create(Tasks task)
    {
        await _dbContext.Tasks.AddAsync(task);
    }

    public async System.Threading.Tasks.Task Update(Tasks task)
    {
        _dbContext.Tasks.Update(task);
    }

    public void Delete(Tasks task)
    {
        _dbContext.Tasks.Remove(task);
    }
}

