using Domain.Entities;
using IMDb.Domain.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
    }
}
