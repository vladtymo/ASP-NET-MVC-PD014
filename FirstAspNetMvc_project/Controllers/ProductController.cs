using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly CompanyDbContext context;

        public ProductController(CompanyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));

            // 1 - using ViewData
            //ViewData["categoryList"] = categories;

            // 2 - using ViewBag
            ViewBag.CategoryList = categories;

            return View("Upsert");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Upsert");
            }

            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id < 0) return NotFound();

            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
            
            return View("Upsert", product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Upsert", updatedProduct);
            }

            //var product = context.Products.AsNoTracking().FirstOrDefaultAsync(u => u.Id == updatedProduct.Id);

            //if (product == null) return NotFound();

            context.Products.Update(updatedProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id < 0) return NotFound();

            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
