using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstAspNetMvc_project.Models
{
    public class EditUserViewModel
    {
        public User User { get; set; }
        public SelectList Roles { get; set; }
    }
}
