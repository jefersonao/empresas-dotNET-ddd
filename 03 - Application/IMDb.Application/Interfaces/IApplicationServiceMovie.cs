using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Application.Interfaces
{
    public interface IApplicationServiceMovie 
    {
        void Add(Movie movie);

         void Update(Movie movie);

         void Remove(Movie movie);

         IEnumerable<Movie> GetAll();

         Movie GetById(int id);

    }
}
