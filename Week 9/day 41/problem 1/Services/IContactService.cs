using ContactCachingAPI.Models;

namespace ContactCachingAPI.Services;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact?> GetContactByIdAsync(int id);
}
