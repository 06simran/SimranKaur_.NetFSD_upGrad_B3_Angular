using Microsoft.AspNetCore.Mvc;

[Route("calc")]
public class CalculatorController : Controller
{
    [HttpGet("add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public IActionResult Add(int num1, int num2)
    {
        ViewData["Result"] = num1 + num2;
        return View();
    }
}