using Sawlux.Data.Base;
using Sawluz.Model.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sawlux.Service.Base
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>, IRepositorio<TEntity> where TEntity : class
    {
        protected IRepositorioBase<TEntity> repository;

        public ServiceBase(IRepositorioBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public IQueryable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return repository.Get(predicate);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes)
        {
            return repository.Get(predicate, includes);
        }

        public TEntity Find(params object[] key)
        {
            return repository.Find(key);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Save()
        {
            repository.Save();
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public void Add(List<TEntity> obj)
        {
            repository.Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            repository.Delete(predicate);
        }

    }
}
