using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Avatar { get; set; }

        public int? RoleId { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
