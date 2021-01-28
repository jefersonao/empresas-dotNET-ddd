using Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Services
{
    public class ServiceMovie : ServiceBase<Movie>, IServiceMovie
    {
        private readonly IRepositoryMovie repositoryMovie;
        public ServiceMovie(IRepositoryMovie movieRepository)
        : base(movieRepository)
        {
            this.repositoryMovie = movieRepository;
        }

    }
}
