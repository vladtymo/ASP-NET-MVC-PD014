using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CompanyDbContext context;

        // Dependecy Injection
        public CategoryController(CompanyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("Upsert");
            }

            context.Categories.Add(newCategory);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category category = context.Categories.Find(id);

            if (category == null) return NotFound();

            return View("Upsert", category);
        }

        [HttpPost]
        public IActionResult Edit(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("Upsert");
            }

            context.Categories.Update(newCategory);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return NotFound();

            var category = context.Categories.Find(id);

            if (category == null) return NotFound();

            context.Categories.Remove(category);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
