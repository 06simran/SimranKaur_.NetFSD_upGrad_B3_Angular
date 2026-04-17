using ContactCachingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactCachingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;

    public ContactsController(IContactService service) => _service = service;

    /// <summary>
    /// Get all contacts.
    /// 1st request: fetches from repository (CACHE MISS).
    /// Subsequent requests within 60s: returns from cache (CACHE HIT).
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllContactsAsync());

    /// <summary>
    /// Get contact by ID. Each ID is cached individually.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _service.GetContactByIdAsync(id);
        return contact == null
            ? NotFound(new { message = $"Contact with ID {id} not found." })
            : Ok(contact);
    }
}
