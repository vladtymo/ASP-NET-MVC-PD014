using FirstAspNetMvc_project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class UserController : Controller
    {
        private List<User> users = new List<User>();
        public UserController()
        {
            users.Add(new User() { Name = "Vlad", Surname = "Tymo", Email = "rejv434@gmail.com", BirthDate = DateTime.Now });
            users.Add(new User() { Name = "Bob", Surname = "Bobovich", Email = "super4344@gmail.com", BirthDate = DateTime.Now });
            users.Add(new User() { Name = "Igor", Surname = "Rufer", Email = "hgkkkkff@gmail.com", BirthDate = DateTime.Now });
        }

        public IActionResult Index()
        {
            return View(users);
        }
    }
}
