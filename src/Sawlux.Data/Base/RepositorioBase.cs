using Sawlux.Data.Contexto;
using Sawluz.Model.Contrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sawlux.Data.Base
{
   public abstract class RepositorioBase<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        protected SawluxContexto ctx;

        public RepositorioBase(SawluxContexto repo)
        {
            ctx = repo;
        }

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes)
        {
            var query = GetAll().Where(predicate).AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            ctx.Entry<TEntity>(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Add(List<TEntity> obj)
        {
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Set<TEntity>().AddRange(obj);
            ctx.ChangeTracker.DetectChanges();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
