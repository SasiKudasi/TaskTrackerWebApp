using System;
using Task.Core.Models;

namespace Task.Core.Abstraction
{
	public interface ITaskService
	{
        public Task<List<Tasks>> GetAllTasks();
        public Task<Guid> CreateNewTask(Tasks tasks);
    }
}

