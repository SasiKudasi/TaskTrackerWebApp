using System;
using Microsoft.EntityFrameworkCore;
using Task.Core.Abstraction;
using Task.Core.Models;
using Task.DataAccess.Entities;

namespace Task.DataAccess.Repository
{
	public class TaskRepository : ITaskRepository
	{
		private readonly TaskDbContext _dbContext;
		public TaskRepository(TaskDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Tasks>> Get()
		{
			var entity = await _dbContext.Tasks.AsNoTracking().ToListAsync();
			var tasks = entity.Select(t => Tasks.Create(t.Id, t.Title, t.Description, t.Date)).ToList();
			return tasks;
		}

		public async Task<Guid> Create (Tasks tasks)
		{
			var task = new TaskEntity
			{
				Id = tasks.Id,
				Title = tasks.Title,
				Description = tasks.Description,
				Date = tasks.Date
			};

			await _dbContext.Tasks.AddAsync(task);
			await _dbContext.SaveChangesAsync();
			return task.Id;
		}
	}
}

