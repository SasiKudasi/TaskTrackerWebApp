using System;
using Task.Core.Abstraction;
using Task.Core.Models;

namespace Task.Application.Services
{
	public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
		{
            _repository = repository;
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            return await _repository.Get();
        }

        public async Task<Guid> CreateNewTask(Tasks tasks)
        {
            return await _repository.Create(tasks);
        }
	}
}

