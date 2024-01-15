using Microsoft.AspNetCore.Mvc;
using MVC_pv221.Models;
using System.Diagnostics;

namespace MVC_pv221.Controllers
{
    public class HomeController : Controller
    {
      
        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // logic: get/save/validate data

            return View();
        }
        public IActionResult Users()
        {
            return View(); // ~/Views/Home/Users.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
