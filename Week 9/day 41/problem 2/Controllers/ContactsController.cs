using ContactPagingAPI.Models;
using ContactPagingAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactPagingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;

    public ContactsController(IContactRepository repo) => _repo = repo;

    /// <summary>
    /// Get paginated contacts.
    /// Example: GET /api/contacts?pageNumber=2&pageSize=3
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize   = 5)
    {
        // Validate query params
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize   < 1) pageSize   = 5;
        if (pageSize   > 50) pageSize  = 50; // Max page size cap

        var (contacts, totalCount) = await _repo.GetPagedAsync(pageNumber, pageSize);

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var response = new PagedResponse<Contact>
        {
            TotalRecords = totalCount,
            TotalPages   = totalPages,
            CurrentPage  = pageNumber,
            PageSize     = pageSize,
            Data         = contacts
        };

        return Ok(response);
    }
}
