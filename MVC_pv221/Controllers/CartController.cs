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

        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(cartService.GetProducts());
        }

        public IActionResult Add(int id, string returnUrl)
        {
            cartService.Add(id);
            return Redirect(returnUrl);
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            cartService.Remove(id);
            return Redirect(returnUrl);
        }
    }
}
