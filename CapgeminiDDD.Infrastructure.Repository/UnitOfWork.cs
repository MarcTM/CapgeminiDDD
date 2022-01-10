using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public CapgeminiDDDDbContext Context { get; }

        public UnitOfWork(CapgeminiDDDDbContext context)
        {
            Context = context;
        }

        public async Task<bool> Commit()
        {
            await Context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
