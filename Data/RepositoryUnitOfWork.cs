using System;
using System.Collections.Generic;
using ITec.Serveur.Context;
using System.Linq;
using ITec.Serveur.Data.Contracts;

namespace ITec.Serveur.Data.Implementations
{
    public class ITecRepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly ITecContext iTecContext;
        private Dictionary<Type, object> repositories;
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            ITecRepository<T> repository = new ITecRepository<T>(iTecContext);

            repositories.Add(typeof(T), repository);

            return repository;
        }

        public int SaveChanges()
        {
            return iTecContext.SaveChanges();
        }

        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (iTecContext != null)
                    {
                        iTecContext.Dispose();
                    }

                    if (repositories != null)
                    {
                        repositories = null;
                    }
                }



                disposedValue = true;
            }
        }



        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            Dispose(true);
        }

    }
}