using Data;
using FirstAspNetMvc_project.Models;
using FirstAspNetMvc_project.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CompanyDbContext context;

        public HomeController(ILogger<HomeController> logger, CompanyDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();

            return View(products);
        }

        public IActionResult AddToCart(int productId)
        {
            List<int> productIds = HttpContext.Session.Get<List<int>>(WebConstants.cartListKey);

            if (productIds == null)
                productIds = new List<int>();

            productIds.Add(productId);

            HttpContext.Session.Set<List<int>>(WebConstants.cartListKey, productIds);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            HttpContext.Session.SetString("Username", "blabla@ukr.net");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
