using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User : Base
    {
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string Lastname { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(60)]
        public string Password { get; set; }

        [MaxLength(60)]
        public bool isDeleted { get; set; }

        [MaxLength(60)]
        public bool isAdmin { get; set; }

    }
}
