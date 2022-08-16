using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Interfaces;
using Repository.Abstraction.Specification.Queries;

namespace Repository.Abstraction.Specification;

internal class QueryItemSpecificationBuilder<T> : ISpecificationBuilder<T> where T : BaseEntity
{
    /// <summary>
    /// </summary>
    /// <param name="item"></param>
    public QueryItemSpecificationBuilder(QueryItem item)
    {
        Specification = new QueryItemSpecification<T>(item).DefaultSpecification;
    }

    private DefaultSpecification<T> Specification { get; }

    public ISpecificationBuilder<T> Includes(string includes)
    {
        Specification.AddInclude(includes);
        return this;
    }

    public ISpecificationBuilder<T> Includes(Expression<Func<T, object>> expression)
    {
        Specification.AddInclude(expression);
        return this;
    }

    public ISpecificationBuilder<T> OrderBy(OrderBy by, Expression<Func<T, object>> orderByExpression)
    {
        Specification.ApplyOrderBy(by, orderByExpression);
        return this;
    }

    public ISpecificationBuilder<T> Take(int maxResultCount)
    {
        Specification.ApplyMaxResult(maxResultCount);
        return this;
    }

    public ISpecification<T> Build()
    {
        return Specification;
    }
}