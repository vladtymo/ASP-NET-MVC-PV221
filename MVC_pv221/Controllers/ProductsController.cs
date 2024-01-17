using Microsoft.AspNetCore.Mvc;
using MVC_pv221.Data;

namespace MVC_pv221.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // get all products from the db
            var products = context.Products.ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            // get product by ID from the db

            return View(id);
        }
    }
}
