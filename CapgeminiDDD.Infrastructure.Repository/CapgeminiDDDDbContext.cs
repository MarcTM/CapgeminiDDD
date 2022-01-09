using CapgeminiDDD.Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class CapgeminiDDDDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Direction> Direction { get; set; }

        public CapgeminiDDDDbContext(DbContextOptions<CapgeminiDDDDbContext> options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DbURL"));
        }
    }
}
