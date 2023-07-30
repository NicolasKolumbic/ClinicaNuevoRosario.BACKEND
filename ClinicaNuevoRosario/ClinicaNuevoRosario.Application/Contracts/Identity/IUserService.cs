

using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Contracts.Identity
{
    public interface IUserService<T, K>
    {
        Task<T> GetUserByAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task<List<K>> GetUsersAsync();


    }
}
