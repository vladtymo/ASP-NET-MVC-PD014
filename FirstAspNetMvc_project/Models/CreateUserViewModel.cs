using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Models
{
    public class CreateUserViewModel
    {
        public User User { get; set; }
        public SelectList Roles { get; set; }
    }
}
