using Data;
using Data.Entities;
using FirstAspNetMvc_project.Models;
using FirstAspNetMvc_project.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class UserController : Controller
    {
        //private CompanyDbContext context = new CompanyDbContext();
        private readonly CompanyDbContext context;
        private readonly IWebHostEnvironment host;

        public UserController(CompanyDbContext context, IWebHostEnvironment host)
        {
            this.context = context;
            this.host = host;
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

            if (HttpContext.Request.Form.Files.Any())
            {
                IFormFile avatar = HttpContext.Request.Form.Files[0];

                string avatarPath = SaveFile(avatar);

                newUser.Avatar = avatarPath;
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

        // Other methods
        private string SaveFile(IFormFile file)
        {
            // get destination path
            string root = host.WebRootPath;
            string folder = WebConstants.userAvatarsPath;
            string name = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);

            string fileName = name + extension;

            // root + folder + name + extension
            string path = Path.Combine(root, folder, fileName);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return fileName;
        }
    }
}
