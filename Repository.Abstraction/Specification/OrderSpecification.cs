using System.Linq.Expressions;

namespace Repository.Abstraction.Specification;

public record OrderSpecification<T>(OrderBy OrderBy, Expression<Func<T, object>> OrderExpression);