using ContactWebAPI.Models;

namespace ContactWebAPI.Interfaces
{
    /// <summary>
    /// Repository contract for contact data access.
    /// Follows Dependency Inversion Principle — controllers depend on this, not the concrete class.
    /// </summary>
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task<Contact> AddAsync(Contact contact);
        Task<Contact?> UpdateAsync(int id, Contact contact);
        Task<bool> DeleteAsync(int id);
    }
}
