using Microsoft.EntityFrameworkCore;
using Plantsist.AppProGateway.Repository.Repositories.DbContext;
using Repository.Abstraction;
using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Interfaces;
using Repository.Extensions;

namespace Repository;

/// <summary>
///     通用型Repository：使用EF Core存取資料庫的 CRUD 基本操作.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <seealso cref="IRepository" />
internal class MasterGenericRepository<TEntity> : IRepository<TEntity> where TEntity :BaseEntity
{
    private readonly DbEntities _dbContext;

    public MasterGenericRepository( DbEntities dbContext)
    {
        _dbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    private DbSet<TEntity> DbSet { get; }

    public virtual void Insert(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        DbSet.Add(entity);
    }

  
    /// <summary>
    ///     將Entity 狀態改為以更新
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Update(TEntity entity)
    {
        var entry = _dbContext.Entry(entity);
        //DbSet.Update(entity);
        entry.State = EntityState.Modified;
    }

  
    public virtual void Delete(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        DbSet.Remove(entity);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> seSpecification, CancellationToken ctx)
    {
        var queryable = _dbContext.Set<TEntity>().AsQueryable();
        var query = seSpecification.GetQuery(queryable);
        return await query.AsAsyncEnumerable().FirstOrDefaultAsync(cancellationToken: ctx);
    }

    public async Task<IEnumerable<TEntity>> SelectAsync(ISpecification<TEntity> seSpecification, CancellationToken ctx)
    {
        var queryable = _dbContext.Set<TEntity>().AsQueryable();
        var query = seSpecification.GetQuery(queryable);

        return await query.AsAsyncEnumerable().ToArrayAsync(ctx);
    }


}