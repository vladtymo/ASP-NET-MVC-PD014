using FirstAspNetMvc_project.Data;
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
        //private CompanyDbContext context = new CompanyDbContext();
        private readonly CompanyDbContext context;

        public UserController(CompanyDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(context.Users.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create));
            }

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
