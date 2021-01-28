using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : Base
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
