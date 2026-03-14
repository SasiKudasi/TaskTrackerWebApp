namespace Task.Core.Abstraction;

public interface ITaskUnitOfWork
{
    System.Threading.Tasks.Task CommitAsync(CancellationToken ct);
}
