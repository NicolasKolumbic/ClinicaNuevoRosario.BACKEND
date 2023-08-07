using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Extensions
{
    public static class AndAlsoExpression
    {
        public static Expression<Func<TDomain, bool>> AndAlso<TDomain>(this Expression<Func<TDomain, bool>> expression,
                                                                       Expression<Func<TDomain, bool>> otherExpression)
        {
            ParameterExpression param = expression.Parameters[0];
            if (ReferenceEquals(param, otherExpression.Parameters[0]))
                return Expression.Lambda<Func<TDomain, bool>>(Expression.AndAlso(expression.Body, otherExpression.Body), param);

            return Expression.Lambda<Func<TDomain, bool>>(Expression.AndAlso(expression.Body, Expression.Invoke(otherExpression, param)), param);
        }
    }
}
