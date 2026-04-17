using ContactManagement.API.Exceptions;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(IContactRepository repo, ILogger<ContactsController> logger)
    {
        _repo   = repo;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Fetching all contacts at {Time}", DateTime.UtcNow);
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        if (contact == null)
            throw new ContactNotFoundException(id);
        return Ok(contact);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] ContactInfo contact)
    {
        if (!ModelState.IsValid)
            throw new Exceptions.ValidationException("Invalid contact data provided.");
        var created = await _repo.CreateAsync(contact);
        _logger.LogInformation("Contact created: ID={Id}, Name={First} {Last}",
            created.ContactId, created.FirstName, created.LastName);
        return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
    {
        if (!ModelState.IsValid)
            throw new Exceptions.ValidationException("Invalid contact data provided.");
        var updated = await _repo.UpdateAsync(id, contact);
        if (updated == null)
            throw new ContactNotFoundException(id);
        _logger.LogInformation("Contact updated: ID={Id}", id);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repo.DeleteAsync(id);
        if (!result)
            throw new ContactNotFoundException(id);
        _logger.LogInformation("Contact deleted: ID={Id}", id);
        return Ok(new { message = $"Contact {id} deleted successfully." });
    }
}
