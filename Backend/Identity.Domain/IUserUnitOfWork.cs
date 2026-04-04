namespace Identity.Domain;

public interface IUserUnitOfWork
{
    System.Threading.Tasks.Task CommitAsync(CancellationToken ct);
}
