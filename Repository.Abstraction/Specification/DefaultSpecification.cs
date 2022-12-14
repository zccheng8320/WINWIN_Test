using Repository.Abstraction.Specification.Interfaces;
using System.Linq.Expressions;
using Models.Entities;

namespace Repository.Abstraction.Specification;

internal class DefaultSpecification<T> : ISpecification<T> where T : BaseEntity
{
    private readonly List<Expression<Func<T, object>>> _includes = new();


    private readonly List<string> _includeStrings = new();

    public DefaultSpecification()
    {
    }

    public DefaultSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }
    public IReadOnlyList<Expression<Func<T, object>>> Includes => _includes;


    public IReadOnlyList<string> IncludeStrings => _includeStrings;
    public OrderSpecification<T> OrderSpecification { get; private set; }
    public int? MaxResultCount { get; private set; } = null;

    public void AddInclude(string include)
    {
        _includeStrings.Add(include);
    }

    public void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        _includes.Add(includeExpression);
    }

    public void ApplyOrderBy(OrderBy by, Expression<Func<T, object>> orderByExpression)
    {
        OrderSpecification = new OrderSpecification<T>(by, orderByExpression);
    }

    public void ApplyMaxResult(int maxResult)
    {
        if (maxResult <= 0)
            throw new ArgumentException(nameof(maxResult));
        MaxResultCount = maxResult;
    }
}