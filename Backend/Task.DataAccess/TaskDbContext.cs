using Microsoft.EntityFrameworkCore;
using System;
using Task.Core.Models;
using Task.Core.Shared.Entities;
using Task.DataAccess.Configure;

namespace Task.DataAccess
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
		{
		}
		public DbSet<Tasks> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfiguration(new TaskConfigure());
        }
    }
}

