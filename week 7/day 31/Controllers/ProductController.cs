using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("product")]
public class ProductController : Controller
{
    static List<string> products = new List<string>();

    [HttpGet("index")]
    public IActionResult Index()
    {
        ViewBag.Products = products;
        return View();
    }

    [HttpPost("add")]
    public IActionResult Add(string name, double price, int qty)
    {
        products.Add($"{name} - {price} - {qty}");
        ViewBag.Products = products;
        return View("Index");
    }
}