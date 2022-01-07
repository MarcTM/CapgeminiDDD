using CapgeminiDDD.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class CapgeminiDDDDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        public CapgeminiDDDDbContext(DbContextOptions<CapgeminiDDDDbContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CapgeminiDDD");
        }
    }
}
