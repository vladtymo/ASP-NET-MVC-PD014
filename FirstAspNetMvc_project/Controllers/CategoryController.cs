using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        //private readonly CompanyDbContext context;

        // Dependecy Injection
        public CategoryController(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            //this.context = context;
        }

        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
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

            categoryRepository.Insert(newCategory);
            categoryRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetById(id);

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

            categoryRepository.Update(newCategory);
            categoryRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return NotFound();

            var category = categoryRepository.GetById(id);

            if (category == null) return NotFound();

            categoryRepository.Delete(id);
            categoryRepository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
