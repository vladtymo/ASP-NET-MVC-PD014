using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
