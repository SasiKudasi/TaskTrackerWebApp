using Task.Core.Models;

namespace Task.Core.Abstraction
{
    public interface ITaskRepository
    {
        public System.Threading.Tasks.Task Create(Tasks tasks);
        System.Threading.Tasks.Task GetByIdAsync(Guid id);
        public Task<List<Tasks>> Get();
        System.Threading.Tasks.Task Update(Tasks task);
        void Delete(Tasks task);
    }
}

