using Microsoft.AspNetCore.Mvc;

[Route("feedback")]
public class FeedbackController : Controller
{
    [HttpGet("form")]
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost("form")]
    public IActionResult Form(string name, string comments, int rating)
    {
        if (rating >= 4)
            ViewData["Message"] = "Thank You for your positive feedback!";
        else
            ViewData["Message"] = "We will improve based on your feedback.";

        return View();
    }
}