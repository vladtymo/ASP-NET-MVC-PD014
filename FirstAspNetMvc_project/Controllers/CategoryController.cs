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
        private readonly IUnitOfWork unitOfWork;
        //private readonly IRepository<Category> categoryRepository;
        //private readonly CompanyDbContext context;

        // Dependecy Injection
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.categoryRepository = categoryRepository;
            //this.context = context;
        }

        public IActionResult Index()
        {
            return View(unitOfWork.CategoryRepository.GetAll());
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

            unitOfWork.CategoryRepository.Insert(newCategory);
            unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category category = unitOfWork.CategoryRepository.GetById(id);

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

            unitOfWork.CategoryRepository.Update(newCategory);
            unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return NotFound();

            var category = unitOfWork.CategoryRepository.GetById(id);

            if (category == null) return NotFound();

            unitOfWork.CategoryRepository.Delete(id);
            unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
