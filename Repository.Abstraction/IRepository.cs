using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Interfaces;

namespace Repository.Abstraction;
/// <summary>
///     操作資料表介面
/// </summary>
public interface IRepository
{

}

/// <summary>
///     泛型操作資料表介面：提供單一Entity做共用性的CRUD操作
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IRepository<TEntity> : IRepository where TEntity : BaseEntity
{
    /// <summary>
    ///     Inserts the specified entity.
    ///     新增Entity資料.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Insert(TEntity entity);

    /// <summary>
    ///     更新 Entity 資訊
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

   
    /// <summary>
    ///     Deletes the specified entity.
    ///     刪除Entity資料.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Delete(TEntity entity);


    /// <summary>
    ///     根據<see cref="ISpecification{TEntity}" />>取得資料
    /// </summary>
    /// <returns></returns>
    Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> seSpecification, CancellationToken ctx);
    /// <summary>
    ///     根據<see cref="ISpecification{T}" />>取得資料
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> SelectAsync(ISpecification<TEntity> seSpecification, CancellationToken ctx);

   
}