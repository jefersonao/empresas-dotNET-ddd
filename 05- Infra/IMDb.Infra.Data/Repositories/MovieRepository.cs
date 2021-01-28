using Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Infra.Data.Repositorys
{
    public class RepositoryMovie : RepositoryBase<Movie>, IRepositoryMovie
    {
        protected readonly DB _ct;
     
        public RepositoryMovie(DB context)
            : base(context)
        {
            this._ct = context;
        }
    }
}
