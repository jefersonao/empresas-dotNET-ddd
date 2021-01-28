using Domain.Entities;
using IMDb.Application.Interfaces;
using IMDb.Domain.Interfaces.Services;
using IMDb.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Application.Services
{
    public class ApplicationServiceMovie : IApplicationServiceMovie
    {
        private readonly IServiceMovie serviceMovie;

        public ApplicationServiceMovie(IServiceMovie serviceMovie)
        {
            this.serviceMovie = serviceMovie;
        }

        public void Add(Movie movie)
        {
            serviceMovie.Add(movie);
        }

        public void Update(Movie movie)
        {
            serviceMovie.Update(movie);
        }

        public void Remove(Movie movie)
        {
            serviceMovie.Delete(movie.Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return serviceMovie.GetAll();
        }

        public Movie GetById(int id)
        {
            return serviceMovie.GetById(id);
        }
    }
}
