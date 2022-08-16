using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

namespace Repository.Abstraction.Specification.Queries;

public class QueryItemExpressionParser
{
    private static Expression ParseQueryItem<T>(
        QueryItem queryItem,
        ParameterExpression parm)
    {
        var @operator = queryItem.QueryMode;
        var field = queryItem.FieldName;

        var value = queryItem.GetValue();

        var property = Expression.Property(parm, field);


        if (queryItem.QueryMode == QueryMode.Equal || queryItem.ValueType != ValueType.String)
        {
            var toCompare = Expression.Constant(value);
            var left = Expression.Equal(property, toCompare);
            return left;
        }


        return @operator switch
        {
            QueryMode.Contain => Expression.Call(property, GetStringMethodInfo("Contains"), Expression.Constant(value, typeof(string))),
            QueryMode.StartWith => Expression.Call(property, GetStringMethodInfo("StartsWith"), Expression.Constant(value, typeof(string))),
            QueryMode.EndWith => Expression.Call(property, GetStringMethodInfo("EndsWith"), Expression.Constant(value, typeof(string))),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryItem">查詢條件</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Expression<Func<T, bool>> ParseExpressionOf<T>(QueryItem queryItem)
    {
        var itemExpression = Expression.Parameter(typeof(T));
        var conditions = ParseQueryItem<T>(queryItem, itemExpression);
        if (conditions.CanReduce == true)
        {
            conditions = conditions.ReduceAndCheck();
        }


        var query = Expression.Lambda<Func<T, bool>>(conditions, itemExpression);
        return query;
    }

    private static MethodInfo GetStringMethodInfo(string methodName)
    {
        return typeof(string).GetMethods()
            .Where(m => m.Name == methodName).Single(m =>
                m.GetParameters().Length == 1 && m.GetParameters().First().ParameterType == typeof(string));
    }
}