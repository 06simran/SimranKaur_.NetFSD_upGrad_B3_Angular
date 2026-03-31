using Microsoft.AspNetCore.Mvc;

[Route("student")]
public class StudentController : Controller
{
    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    public IActionResult Register(string name, int age, string course)
    {
        ViewBag.Name = name;
        ViewBag.Age = age;
        ViewBag.Course = course;

        return View("Display"); // NO redirect (important)
    }

    [HttpGet("display")]
    public IActionResult Display()
    {
        return View();
    }
}