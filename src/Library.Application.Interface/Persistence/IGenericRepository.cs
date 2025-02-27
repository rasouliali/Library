using System.Linq.Expressions;

namespace Library.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        /* Commands */
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity, bool fromDeleted = false);
        Task<bool> DeleteAsync(int id);
        /* Queries */
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync(string[] includeProperties = null);
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
