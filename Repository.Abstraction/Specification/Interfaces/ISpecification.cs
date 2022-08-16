using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Queries;

namespace Repository.Abstraction.Specification.Interfaces;

public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    IReadOnlyList<Expression<Func<TEntity, object>>> Includes { get; }
    IReadOnlyList<string> IncludeStrings { get; }
    OrderSpecification<TEntity>? OrderSpecification { get; }
    int? MaxResultCount { get; }

    public static ISpecificationBuilder<TEntity> CreateBuilder()
    {
        return new DefaultSpecificationBuilder<TEntity>();
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="predicate">查詢條件</param>
    /// <returns></returns>
    public static ISpecificationBuilder<TEntity> CreateBuilder(Expression<Func<TEntity, bool>> predicate)
    {
        return new DefaultSpecificationBuilder<TEntity>(predicate);
    }

    public static ISpecificationBuilder<TEntity> CreateBuilder(QueryItem queryItem)
    {
        return new QueryItemSpecificationBuilder<TEntity>(queryItem);
    }
}