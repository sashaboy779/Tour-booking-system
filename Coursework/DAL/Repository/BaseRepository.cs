using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Interface;
using DAL.EF;

namespace DAL.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext db;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            db = context;
            dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public void Delete(TEntity item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(TEntity item)
        {
            dbSet.Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
