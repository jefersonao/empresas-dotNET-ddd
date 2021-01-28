using IMDb.Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Repositorys;
using IMDb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDb.Infra.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : Base
    {
        protected readonly DB _ct;

        public RepositoryBase(DB ct)
        : base()
        {
            _ct = ct;
        }

        public void Add(TEntity entity)
        {
            _ct.InitTransaction();
            _ct.Set<TEntity>().Add(entity);
            _ct.SendChanges();

        }
        public void Update(TEntity entity)
        {
            _ct.InitTransaction();
            _ct.Set<TEntity>().Attach(entity);

            _ct.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ct.SendChanges();
        }
        public void Delete(int id)
        {
            var entidade = GetById(id);
            if (entidade != null)
            {
                _ct.InitTransaction();
                _ct.Set<TEntity>().Remove(entidade);
                _ct.SendChanges();
            }
        }
        public TEntity GetById(int id)
        {
            return _ct.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _ct.Set<TEntity>().ToList();
        }


    }
}
