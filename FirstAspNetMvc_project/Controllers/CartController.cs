using Data;
using Data.Entities;
using FirstAspNetMvc_project.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class CartController : Controller
    {
        private readonly CompanyDbContext context;

        public CartController(CompanyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<int> productIds = HttpContext.Session.Get<List<int>>(WebConstants.cartListKey);

            List<Product> products = new List<Product>();

            if (productIds != null)
                products = context.Products.Where(i => productIds.Contains(i.Id)).ToList();

            return View(products);
        }

        
    }
}
