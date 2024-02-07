using Microsoft.AspNetCore.Mvc;

namespace MVC_pv221.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
