using Nawaranga.Models;

namespace Nawaranga.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()  //GenericRepository
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
