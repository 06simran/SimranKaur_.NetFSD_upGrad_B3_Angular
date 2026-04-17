using ContactRateLimitAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ContactRateLimitAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("fixed")]   // Apply the "fixed" rate limit policy to this controller
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;

    public ContactsController(IContactRepository repo) => _repo = repo;

    /// <summary>
    /// Get all contacts.
    /// Rate limited: 5 requests per 60 seconds per IP.
    /// Returns 429 Too Many Requests when limit exceeded.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());
}
