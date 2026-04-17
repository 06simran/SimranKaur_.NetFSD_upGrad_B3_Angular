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

    public ContactsController(IContactRepository repo)
    {
        _repo = repo;
    }

    // GET /api/contacts  (Admin + User)
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());

    // GET /api/contacts/{id}  (Admin + User)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        if (contact == null)
            return NotFound(new { message = $"Contact with ID {id} not found." });
        return Ok(contact);
    }

    // POST /api/contacts  (Admin only)
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] ContactInfo contact)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _repo.CreateAsync(contact);
        return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
    }

    // PUT /api/contacts/{id}  (Admin only)
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _repo.UpdateAsync(id, contact);
        if (updated == null)
            return NotFound(new { message = $"Contact with ID {id} not found." });
        return Ok(updated);
    }

    // DELETE /api/contacts/{id}  (Admin only)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repo.DeleteAsync(id);
        if (!result)
            return NotFound(new { message = $"Contact with ID {id} not found." });
        return Ok(new { message = $"Contact {id} deleted successfully." });
    }
}
