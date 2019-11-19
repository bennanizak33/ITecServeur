using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ITec.Serveur.Data.Contracts
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        IQueryable<T> Get(Expression<Func<T,bool>> predicate = null);
        T FindById(object id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        void Unchange(T entity);

    }
}