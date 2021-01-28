using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Rating : Base
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Rate { get; set; }
    }
}