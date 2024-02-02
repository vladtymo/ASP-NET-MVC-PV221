using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_pv221.Helpers;
using System.Text.Json;

namespace MVC_pv221.Controllers
{
    public class CartController : Controller
    {
        const string key = "cart_items_key";
        private readonly IProductsService productsService;

        public CartController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>(key) ?? new();
            return View(productsService.Get(ids));
        }

        public IActionResult Add(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>(key) ?? new();
            ids.Add(id);

            HttpContext.Session.SetString(key, JsonSerializer.Serialize(ids));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            // TODO
            return RedirectToAction(nameof(Index));
        }
    }
}
