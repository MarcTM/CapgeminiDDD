namespace CapgeminiDDD.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public CapgeminiDDDDbContext Context { get; }

        public UnitOfWork(CapgeminiDDDDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
