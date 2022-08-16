using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Interfaces;
using Repository.Abstraction.Specification.Queries;

namespace Repository.Abstraction.Specification;

internal class QueryItemSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
{
    private ISpecification<TEntity> _specification => DefaultSpecification;
    public DefaultSpecification<TEntity> DefaultSpecification { get; private set; }
    public QueryItemSpecification(QueryItem queryItem)
    {
        var exp = QueryItemExpressionParser.ParseExpressionOf<TEntity>(queryItem);

        DefaultSpecification = new DefaultSpecification<TEntity>(exp);
    }

    public Expression<Func<TEntity, bool>>? Criteria => _specification.Criteria;
    public IReadOnlyList<Expression<Func<TEntity, object>>> Includes => _specification.Includes;
    public IReadOnlyList<string> IncludeStrings => _specification.IncludeStrings;
    public OrderSpecification<TEntity>? OrderSpecification => _specification.OrderSpecification;
    public int? MaxResultCount => _specification.MaxResultCount;
}