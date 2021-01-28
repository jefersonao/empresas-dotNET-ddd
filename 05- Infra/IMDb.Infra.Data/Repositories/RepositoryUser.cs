using Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Infra.Data.Repositorys
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        protected readonly DB _ct;
        public RepositoryUser(DB context)
            : base(context)
        {
            this._ct = context;
        }
    }
}
