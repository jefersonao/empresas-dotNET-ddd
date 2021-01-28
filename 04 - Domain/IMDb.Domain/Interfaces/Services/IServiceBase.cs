using IMDb.Domain.Entities;
using IMDb.Domain.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : Base
    {    
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
