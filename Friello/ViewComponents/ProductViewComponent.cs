﻿using Friello.DAL;
using Friello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friello.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public ProductViewComponent (AppDbContext context)
        {
            _context = context; 
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Product> products = _context.Products.Include(p => p.CategoryName).Take(take).ToList();
            return View(await Task.FromResult(products));
        }
    }
}
