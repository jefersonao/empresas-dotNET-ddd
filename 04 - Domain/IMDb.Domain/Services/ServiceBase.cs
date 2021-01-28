using IMDb.Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Repositorys;
using IMDb.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
         where TEntity : Base
    {
        protected readonly IRepositoryBase<TEntity> _rp;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this._rp = repository;
        }

        public void Add(TEntity entity)
        {
            _rp.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _rp.Update(entity);
        }
        public void Delete(int id)
        {
            _rp.Delete(id);
        }
        public TEntity GetById(int id)
        {
            return _rp.GetById(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _rp.GetAll();
        }

    }
}
