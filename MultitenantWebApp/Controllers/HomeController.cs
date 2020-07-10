using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MultitenantWebApp.Extensions;
using MultitenantWebApp.Models;

namespace MultitenantWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ITenantProvider _tenantProvider;

        public HomeController(ApplicationDbContext context, ITenantProvider tenantProvider, ILogger<HomeController> logger)
        {
            _context = context;
            _tenantProvider = tenantProvider;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_context.Database.EnsureCreated();
            _context.AddData();

            var grouped = from b in _context.Products
                          group b.Id by b.Category.Name into g
                          select new
                          {
                              Key = g.Key,
                              Products = g.Count()
                          };
            var result = grouped.ToList();
            var model = _context.Products
                                .Include(b => b.Category)
                                .ToList();

            return View("ProductList", model);
        }

        public IActionResult Category(int id)
        {
            var model = _context.Categories
                                   .Include(c => c.Products)
                                   .First(c => c.Id == id)
                                   .Products;

            return View("ProductList", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _context.TenantId + ";" + _tenantProvider.GetTenant().Id;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = HttpContext.Request.Host.ToString();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
