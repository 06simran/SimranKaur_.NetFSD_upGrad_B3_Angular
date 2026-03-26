using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("Product")]   // base route
    public class PrdController : Controller
    {
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { productId = 101, Pname = "Laptop", Category = "Electronics", Price = 50000 },
                new Product { productId = 102, Pname = "Mobile", Category = "Electronics", Price = 20000 }
            };
        }

        // /Product
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(GetProducts());
        }

        // /Product/Details/101
        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            var prd = GetProducts().FirstOrDefault(p => p.productId == id);

            if (prd == null)
                return Content("Product not found");

            return View(prd);
        }
    }
}