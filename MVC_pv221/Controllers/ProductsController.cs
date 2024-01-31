﻿using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_pv221.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        private void LoadCategories()
        {
            // Send temporary data to view
            // 1: TempData[key] = value
            // 2: ViewBag.Key = value
            var categories = productsService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
        }

        public IActionResult Index()
        {
            // get all products from the db
            return View(productsService.GetAll());
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto model)
        {
            // model validation
            if (!ModelState.IsValid) 
            {
                LoadCategories();
                return View();
            }

            productsService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = productsService.Get(id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View();
            }

            productsService.Edit(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id, string? returnUrl)
        {
            // get product by ID from the db
            var product = productsService.Get(id);
            if (product == null) return NotFound();
           
            ViewBag.ReturnUrl = returnUrl;
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
