using Microsoft.EntityFrameworkCore;
using Task.Core.Abstraction;
using Task.Core.Models;
using Task.Shared.Contracts;
namespace Task.DataAccess.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _dbContext;
    public TaskRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tasks>> GetList(Specification specs)
    {
        var query = _dbContext.Tasks.AsNoTracking().AsQueryable();

        if (specs.Sorting.Equals("desc"))
        {
          query =  query.OrderByDescending(x => x.Title);
        }
        if (specs.Sorting.Equals("asc"))
        {
            query = query.OrderBy(x => x.Title);
        }

        return await query
            .Skip((specs.PageNum - 1) * specs.PageSize)
            .Take(specs.PageSize)
            .ToListAsync();
    }

    public async Task<Tasks?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
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

