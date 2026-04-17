using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.Repository;

public interface IContactRepository
{
    Task<IEnumerable<ContactInfo>> GetAllAsync();
    Task<ContactInfo?> GetByIdAsync(int id);
    Task<ContactInfo> CreateAsync(ContactInfo contact);
    Task<ContactInfo?> UpdateAsync(int id, ContactInfo contact);
    Task<bool> DeleteAsync(int id);
}
