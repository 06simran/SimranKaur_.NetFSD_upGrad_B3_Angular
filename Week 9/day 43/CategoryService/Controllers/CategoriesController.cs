using CategoryService.Models;
using CategoryService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    // GET: api/categories — Admin and User
    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _service.GetAllAsync();
        return Ok(categories);
    }

    // GET: api/categories/5 — Admin and User
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);
        if (category == null) return NotFound(new { message = $"Category with ID {id} not found." });
        return Ok(category);
    }

    // POST: api/categories — Admin only
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] Category category)
    {
        var created = await _service.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = created.CategoryId }, created);
    }

    // PUT: api/categories/5 — Admin only
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] Category category)
    {
        var updated = await _service.UpdateAsync(id, category);
        if (updated == null) return NotFound(new { message = $"Category with ID {id} not found." });
        return Ok(updated);
    }

    // DELETE: api/categories/5 — Admin only
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound(new { message = $"Category with ID {id} not found." });
        return Ok(new { message = "Category deleted successfully." });
    }
}
