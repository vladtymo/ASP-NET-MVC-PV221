using Microsoft.AspNetCore.Mvc;
using MVC_pv221.Data;

namespace MVC_pv221.Controllers
{
    public class ProductsController : Controller
    {
        private ShopDbContext context;
        public ProductsController()
        {
            context = new ShopDbContext();
        }

        public IActionResult Index()
        {
            // get all products from the db
            var products = context.Products.ToList();

            return View(products);
        }
    }
}
