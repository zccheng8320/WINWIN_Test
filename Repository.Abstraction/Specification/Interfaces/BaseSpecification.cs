using System.Linq.Expressions;
using Models.Entities;

namespace Repository.Abstraction.Specification.Interfaces;

public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    private readonly List<Expression<Func<T, object>>> _includes = new();


    private readonly List<string> _includeStrings = new();

    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }
    public IReadOnlyList<Expression<Func<T, object>>> Includes => _includes;


    public IReadOnlyList<string> IncludeStrings => _includeStrings;
    public OrderSpecification<T> OrderSpecification { get; private set; }
    public int? MaxResultCount { get; private set; }

    protected void AddInclude(string include)
    {
        _includeStrings.Add(include);
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        _includes.Add(includeExpression);
    }

    protected void ApplyOrderBy(OrderBy by, Expression<Func<T, object>> orderByExpression)
    {
        OrderSpecification = new OrderSpecification<T>(by, orderByExpression);
    }
}