using Infra.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private Context.Context ctx = new Context.Context();

        public virtual IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public virtual TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public virtual void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public virtual void SaveAll()
        {
            ctx.SaveChanges();
        }

        public virtual void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public virtual void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
                GC.Collect();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
