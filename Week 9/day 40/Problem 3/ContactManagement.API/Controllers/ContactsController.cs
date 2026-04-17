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

    /// <summary>Get all contacts including Company and Department details</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ContactInfo>), 200)]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Fetching all contacts at {Time}", DateTime.UtcNow);
        return Ok(await _repo.GetAllAsync());
    }

    /// <summary>Get a specific contact by ID</summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ContactInfo), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        if (contact == null)
            throw new ContactNotFoundException(id);
        return Ok(contact);
    }

    /// <summary>Create a new contact — Admin only</summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ContactInfo), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] ContactInfo contact)
    {
        if (!ModelState.IsValid)
            throw new Exceptions.ValidationException("Invalid contact data provided.");
        var created = await _repo.CreateAsync(contact);
        _logger.LogInformation("Contact created: ID={Id}, Name={First} {Last}",
            created.ContactId, created.FirstName, created.LastName);
        return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
    }

    /// <summary>Update an existing contact — Admin only</summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ContactInfo), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
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

    /// <summary>Delete a contact — Admin only</summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repo.DeleteAsync(id);
        if (!result)
            throw new ContactNotFoundException(id);
        _logger.LogInformation("Contact deleted: ID={Id}", id);
        return Ok(new { message = $"Contact {id} deleted successfully." });
    }
}
