using ContactPagingAPI.Models;

namespace ContactPagingAPI.Repository;

public interface IContactRepository
{
    Task<(IEnumerable<Contact> Contacts, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
}
