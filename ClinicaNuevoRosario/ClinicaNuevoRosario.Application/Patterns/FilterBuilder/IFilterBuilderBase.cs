using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Patterns.FilterBuilder
{
    public interface IFilterBuilderBase<TDomain>
    {
        void AddExpression(Expression<Func<TDomain, bool>> filterExpression);
        Expression<Func<TDomain, bool>> GetFilterExpression();
    }
}
