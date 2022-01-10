using System;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CapgeminiDDDDbContext Context { get; }

        void Commit();
    }
}
