using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Abstraction.Specification;
using Repository.Abstraction.Specification.Interfaces;

namespace Repository.Extensions;

public static class SpecificationExtensions
{
    public static IQueryable<TEntity> GetQuery<TEntity>(this ISpecification<TEntity> specification,
        IQueryable<TEntity> inputQuery) where TEntity : BaseEntity
    {
        var query = inputQuery;

        // modify the IQueryable using the specification's criteria expression
        if (specification.Criteria != null) query = query.Where(specification.Criteria);

        // Includes all expression-based includes
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        // Include any string-based include statements
        query = specification.IncludeStrings.Aggregate(query,
            (current, include) => current.Include(include));
        var orderSpec = specification.OrderSpecification;

        // Apply ordering if expressions are set
        if (orderSpec != null)
        {
            if (orderSpec.OrderBy == OrderBy.Ascending)
                query = query.OrderBy(orderSpec.OrderExpression);
            else
                query = query.OrderByDescending(orderSpec.OrderExpression);
        }

        if (specification.MaxResultCount != null)
        {
            query = query.Take(specification.MaxResultCount.Value);
        }

        return query;
    }
}