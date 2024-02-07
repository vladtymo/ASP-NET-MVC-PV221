using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_pv221.Models;
using System.Diagnostics;

namespace MVC_pv221.Controllers
{
    public class HomeController : Controller
    {
        private List<UserTest> users = new();
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            users.Add(new UserTest() { Id = 20, Login = "BlablaBob"});
            users.Add(new UserTest() { Id = 44, Login = "BlablaMax" });

            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            return View(productsService.GetAll());
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
