using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification.Interfaces;

namespace Repository.Abstraction.Specification;

internal class DefaultSpecificationBuilder<T> : ISpecificationBuilder<T> where T : BaseEntity
{
    public DefaultSpecificationBuilder()
    {
        Specification = new DefaultSpecification<T>();
    }


    /// <summary>
    /// </summary>
    /// <param name="criteria">查詢條件</param>
    public DefaultSpecificationBuilder(Expression<Func<T, bool>> criteria)
    {
        Specification = new DefaultSpecification<T>(criteria);
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