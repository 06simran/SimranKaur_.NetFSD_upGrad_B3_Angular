using ContactPagingAPI.Data;
using ContactPagingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactPagingAPI.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context) => _context = context;

    public async Task<(IEnumerable<Contact> Contacts, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
    {
        // Get total count first
        var totalCount = await _context.Contacts.CountAsync();

        // Apply Skip() and Take() for pagination
        var contacts = await _context.Contacts
            .OrderBy(c => c.ContactId)
            .Skip((pageNumber - 1) * pageSize)   // Skip records of previous pages
            .Take(pageSize)                        // Take only the current page records
            .ToListAsync();

        return (contacts, totalCount);
    }
}
