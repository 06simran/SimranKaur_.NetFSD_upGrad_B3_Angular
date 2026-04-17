using ContactRateLimitAPI.Models;

namespace ContactRateLimitAPI.Repository;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
}
