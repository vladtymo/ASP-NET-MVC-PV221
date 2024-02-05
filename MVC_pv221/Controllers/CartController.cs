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
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(cartService.GetProducts());
        }

        public IActionResult Add(int id)
        {
            cartService.Add(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            cartService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
