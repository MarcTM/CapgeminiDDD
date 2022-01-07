using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public interface IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAsync();

        Task<bool> CreateAsync(Student entity);

        Task<Student> UpdateAsync(Student entity, int id);

        Task<bool> DeleteAsync(int id);
    }
}
