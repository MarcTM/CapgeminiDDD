using System;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CapgeminiDDDDbContext Context { get; }

        Task<bool> Commit();
    }
}
