using Microsoft.AspNetCore.Mvc;
using ContactService.DTOs;
using ContactService.Services;

namespace ContactService.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;

    public ContactsController(IContactService service)
    {
        _service = service;
    }

    /// <summary>Get all contacts</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>Get contact by ID</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result is null) return NotFound(new { message = $"Contact {id} not found." });
        return Ok(result);
    }

    /// <summary>Add a new contact</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ContactId }, result);
    }

    /// <summary>Update an existing contact</summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateContactDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        if (result is null) return NotFound(new { message = $"Contact {id} not found." });
        return Ok(result);
    }

    /// <summary>Delete a contact</summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound(new { message = $"Contact {id} not found." });
        return NoContent();
    }
}
