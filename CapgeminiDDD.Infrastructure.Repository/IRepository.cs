using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetOneAsync(int id);

        Task<bool> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity, int id);

        Task<bool> DeleteAsync(int id);
    }
}
