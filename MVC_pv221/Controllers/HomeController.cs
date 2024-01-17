using Microsoft.AspNetCore.Mvc;
using MVC_pv221.Data;
using MVC_pv221.Models;
using System.Diagnostics;

namespace MVC_pv221.Controllers
{
    public class HomeController : Controller
    {
        private List<User> users = new();

        public HomeController()
        {
            users.Add(new User() { Id = 20, Login = "BlablaBob"});
            users.Add(new User() { Id = 44, Login = "BlablaMax" });
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
            return View(users); // ~/Views/Home/Users.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
