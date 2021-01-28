using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Actor : Base
    {
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
