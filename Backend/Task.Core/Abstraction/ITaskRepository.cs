using Task.Core.Models;
using Task.Shared.Contracts;

namespace Task.Core.Abstraction
{
    public interface ITaskRepository
    {
        public System.Threading.Tasks.Task Create(Tasks tasks);
        Task<Tasks?> GetByIdAsync(Guid id);
        public Task<List<Tasks>> GetList(Specification specification);
        System.Threading.Tasks.Task Update(Tasks task);
        void Delete(Tasks task);
    }
}

