using System;
using Task.Core.Models;

namespace Task.Core.Abstraction
{
	public interface ITaskRepository
	{
        public Task<Guid> Create(Tasks tasks);
        public Task<List<Tasks>> Get();
    }
}

