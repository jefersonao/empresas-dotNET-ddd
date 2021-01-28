using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Rating : Base
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }

        public int MovieId { get; set; }

        [Range(0, 4)]
        public int Rate { get; set; }
    }
}
