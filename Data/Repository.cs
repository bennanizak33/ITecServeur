using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITec.Serveur.Context;
using ITec.Serveur.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ITec.Serveur.Data.Implementations
{
    class ITecRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly ITecContext iTecContext;
        private DbSet<T> dbSet;

        public ITecRepository(ITecContext iTecContext)
        {
            this.iTecContext = iTecContext;
            this.dbSet = this.iTecContext.Set<T>();
        }
        
        public void Add(T entity)
        {
            if (entity != null)
            {
                iTecContext.Entry(entity).State = EntityState.Added;
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Delete(object id)
        {
            Delete(dbSet.Find(id));
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T FindById(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (System.Exception)
            {

                return default(T);
            }
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return dbSet.Where(predicate);
                }

                return dbSet;
            }
            catch (System.Exception)
            {
                return default(IQueryable<T>);
            }
        }

        public void Unchange(T entity)
        {
            if (entity != null)
            {
                iTecContext.Entry(entity).State = EntityState.Unchanged;
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                iTecContext.Entry(entity).State = EntityState.Modified;
            }
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

                    if (dbSet != null)
                    {
                        dbSet = null;
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}