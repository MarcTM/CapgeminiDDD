using CapgeminiDDD.Common.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly CapgeminiDDDDbContext _context;

        public StudentRepository(CapgeminiDDDDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            IQueryable<Student> query = _context.Student;

            return await query.ToListAsync();
        }

        public async Task<bool> CreateAsync(Student student)
        {
            bool created = false;

            var save = await _context.Student.AddAsync(student);

            if (save != null)
            {
                created = true;
                await _context.SaveChangesAsync();
            }

            return created;
        }

        public async Task<Student> UpdateAsync(Student student, int id)
        {
            Student studentt = null;

            studentt = await _context.Student.FirstOrDefaultAsync(student => student.Id == id);

            studentt.Name = student.Name;
            studentt.Surname = student.Surname;
            studentt.Age = student.Age;

            await _context.SaveChangesAsync();

            return studentt;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool created = false;


            var student = await _context.Student.FirstOrDefaultAsync(student => student.Id == id);
            var save = _context.Student.Remove(student);

            if (save != null)
            {
                created = true;
                await _context.SaveChangesAsync();
            }

            return created;
        }
    }
}
