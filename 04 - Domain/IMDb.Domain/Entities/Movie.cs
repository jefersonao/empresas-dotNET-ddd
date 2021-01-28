using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Movie : Base
    {     
        public string Name { get; set; }
        public string Director { get; set; }
        public string Sinopse { get; set; }
        public int Year { get; set; }
        public string UrlTrailer { get; set; }
        public List<string> urlImages { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public List<Actor> Actors { get; set; }

        public bool isDeleted { get; set; }

    }
}
