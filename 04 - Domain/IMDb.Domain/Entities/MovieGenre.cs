using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MovieGenre : Base
    {
        public int MovieGenreId { get; set; }

        public string Name { get; set; }


    }
}
