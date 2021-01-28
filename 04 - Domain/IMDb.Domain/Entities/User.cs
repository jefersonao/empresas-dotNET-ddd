using IMDb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : Base
    {        
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool isDeleted { get; set; }

        public bool isAdmin { get; set; }

    }
}
