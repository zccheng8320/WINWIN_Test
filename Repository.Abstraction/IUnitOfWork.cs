namespace Repository.Abstraction;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync(CancellationToken ctx);

}