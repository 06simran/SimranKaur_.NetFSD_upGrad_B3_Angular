using ContactManagement.DAL.DbContext;
using ContactManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.DAL.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ContactInfo>> GetAllAsync()
    {
        return await _context.Contacts
            .Include(c => c.Company)
            .Include(c => c.Department)
            .ToListAsync();
    }

    public async Task<ContactInfo?> GetByIdAsync(int id)
    {
        return await _context.Contacts
            .Include(c => c.Company)
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.ContactId == id);
    }

    public async Task<ContactInfo> CreateAsync(ContactInfo contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<ContactInfo?> UpdateAsync(int id, ContactInfo contact)
    {
        var existing = await _context.Contacts.FindAsync(id);
        if (existing == null) return null;

        existing.FirstName   = contact.FirstName;
        existing.LastName    = contact.LastName;
        existing.EmailId     = contact.EmailId;
        existing.MobileNo    = contact.MobileNo;
        existing.Designation = contact.Designation;
        existing.CompanyId   = contact.CompanyId;
        existing.DepartmentId = contact.DepartmentId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null) return false;
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return true;
    }
}
