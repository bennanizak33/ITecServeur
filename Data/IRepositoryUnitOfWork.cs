using System;

namespace ITec.Serveur.Data.Contracts
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        int SaveChanges();

    }
}