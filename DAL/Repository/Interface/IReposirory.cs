using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
