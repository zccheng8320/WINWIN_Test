using System.Linq.Expressions;
using Models.Entities;
using Repository.Abstraction.Specification;

namespace Repository.Abstraction.Specification.Interfaces;

public interface ISpecificationBuilder<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// </summary>
    /// <param name="includes"></param>
    ISpecificationBuilder<TEntity> Includes(string includes);

    ISpecificationBuilder<TEntity> Includes(Expression<Func<TEntity, object>> expression);
    ISpecificationBuilder<TEntity> OrderBy(OrderBy by, Expression<Func<TEntity, object>> orderByExpression);
    ISpecificationBuilder<TEntity> Take(int maxResultCount);
    ISpecification<TEntity> Build();
}