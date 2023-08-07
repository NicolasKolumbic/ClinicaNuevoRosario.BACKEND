using ClinicaNuevoRosario.Application.Extensions;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Patterns.FilterBuilder
{
    public abstract class FilterBuilderBase<TDomain>: IFilterBuilderBase<TDomain>
    {
        private Expression<Func<TDomain, bool>> _expression = (domain) => true;

        public void AddExpression(Expression<Func<TDomain, bool>> filterExpresion)
        {
            _expression = _expression.AndAlso(filterExpresion);
        }

        public Expression<Func<TDomain, bool>> GetFilterExpression()
        {
            return _expression;
        }
    }
}
