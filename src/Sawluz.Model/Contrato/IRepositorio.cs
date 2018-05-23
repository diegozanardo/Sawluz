
using System;
using System.Linq;


namespace Sawluz.Model.Contrato
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes);
        TEntity Find(params object[] key);
        void Update(TEntity obj);
        void Save();
        void Add(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
        void Dispose();
    }
}
