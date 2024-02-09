using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC_pv221.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        public IActionResult Index()
        {
            return View(ordersService.GetAllByUser(UserId));
        }

        public IActionResult Create()
        {
            ordersService.Create(UserId);
            TempData["ToastMessage"] = "Order confirmed successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}
