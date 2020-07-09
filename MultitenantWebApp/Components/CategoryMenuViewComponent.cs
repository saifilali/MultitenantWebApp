using Microsoft.AspNetCore.Mvc;
using MultitenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Components
{
    public class CategoryMenuViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _context.Categories.OrderBy(c => c.Name).ToList();

            return Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
