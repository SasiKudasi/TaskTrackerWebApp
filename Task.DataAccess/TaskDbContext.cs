using System;
using Microsoft.EntityFrameworkCore;
using Task.DataAccess.Entities;

namespace Task.DataAccess
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions<TaskDbContext> options) : base (options)
		{
		}
		public DbSet<TaskEntity> Tasks { get; set; }
	}
}

