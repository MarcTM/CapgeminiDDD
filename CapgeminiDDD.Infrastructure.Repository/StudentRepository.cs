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

        private readonly UnitOfWork _unitOfWork;

        public StudentRepository(CapgeminiDDDDbContext context)
        {
            _context = context;
            _unitOfWork = new(_context);
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Student.Include("Directions").ToListAsync();
        }

        public async Task<Student> GetOneAsync(int id)
        {
            return await _context.Student.Include("Directions").FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<bool> CreateAsync(Student student)
        {
            bool created = false;

            var save = await _context.Student.AddAsync(student);

            if (save != null)
            {
                created = true;
                await _unitOfWork.Commit();
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

            await _unitOfWork.Commit();

            return studentt;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool created = false;

            List<Direction> directions = await _context.Direction.Where(direction => direction.StudentId == id).ToListAsync();
            Student student = await _context.Student.FirstOrDefaultAsync(student => student.Id == id);

            if (directions.Count > 0)
            {
                foreach (var direction in directions)
                {
                    _context.Direction.Remove(direction);
                }
            }

            var save = _context.Student.Remove(student);

            if (save != null)
            {
                created = true;
                await _unitOfWork.Commit();
            }

            return created;
        }
    }
}
