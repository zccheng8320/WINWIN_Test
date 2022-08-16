using Plantsist.AppProGateway.Repository.Repositories.DbContext;
using Repository.Abstraction;

namespace Repository.DbContext;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DbEntities _dbContext;
    private bool _disposed;

    public UnitOfWork(DbEntities dbContext)
    {
        _dbContext = dbContext;

    }
    public Microsoft.EntityFrameworkCore.DbContext Context => _dbContext;
    public async Task<int> SaveChangeAsync(CancellationToken ctx)
    {
     
        var result = await _dbContext.SaveChangesAsync(ctx);
       
        return result;
    }


    #region 資源釋放

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();
        _disposed = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}