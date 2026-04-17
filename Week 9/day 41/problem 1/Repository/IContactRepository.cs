using ContactCachingAPI.Models;

namespace ContactCachingAPI.Repository;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
}
