using TheCoreArchitecture.Common.Repository;
using System;
using System.Threading.Tasks;

namespace TheCoreArchitecture.Common.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repository { get; }
        Task<int> SaveChanges();
        void StartTransaction();
        void CommitTransaction();
        void Rollback();
    }
}
