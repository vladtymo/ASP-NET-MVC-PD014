using Data;
using Data.Entities;
using FirstAspNetMvc_project.Services;
using FirstAspNetMvc_project.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstAspNetMvc_project.Controllers
{
    public class CartController : Controller
    {
        private readonly CompanyDbContext context;
        private readonly IEmailService emailService;

        public CartController(CompanyDbContext context, IEmailService emailService)
        {
            this.context = context;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            List<int> productIds = HttpContext.Session.Get<List<int>>(WebConstants.cartListKey);

            List<Product> products = new List<Product>();

            if (productIds != null)
                products = context.Products.Where(i => productIds.Contains(i.Id)).ToList();

            return View(products);
        }

        public IActionResult Confirm()
        {
            string userEmail = User.Identity.Name;
            emailService.SendAsync(userEmail, "ASP.NET Shop", @"<h1>Hello from App!</h1>");

            return RedirectToAction(nameof(Index));
        }
    }
}
