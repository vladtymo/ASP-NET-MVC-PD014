using FirstAspNetMvc_project.Data;
using FirstAspNetMvc_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id < 0) return NotFound();

            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedUser);
            }

            var user = context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            //var user = await context.Users.FindAsync(updatedUser.Id);

            if (user == null) return NotFound();

            context.Users.Update(updatedUser);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            if (id < 0) return NotFound();

            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
