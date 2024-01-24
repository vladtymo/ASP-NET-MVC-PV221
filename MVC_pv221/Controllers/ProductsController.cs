﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_pv221.Data;
using MVC_pv221.Data.Entities;

namespace MVC_pv221.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        private void LoadCategories()
        {
            // Send temporary data to view
            // 1: TempData[key] = value
            // 2: ViewBag.Key = value
            ViewBag.Categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
        }

        public IActionResult Index()
        {
            // get all products from the db
            var products = context.Products.Include(x => x.Category).ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            // TODO: add validation
            if (!ModelState.IsValid) 
            {
                LoadCategories();
                return View();
            }

            context.Products.Add(model);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            // get product by ID from the db
            var product = context.Products.Find(id);
            context.Entry(product).Reference(x => x.Category).Load();

            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            // delete product by id
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            context.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
