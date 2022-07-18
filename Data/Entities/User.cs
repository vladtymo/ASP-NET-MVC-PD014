using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Avatar { get; set; }
    }
}
