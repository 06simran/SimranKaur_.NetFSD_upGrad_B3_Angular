using WebApplication2.Models;

namespace WebApplication2.DataAccess
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllContactsAsync();
        Task<ContactInfo?> GetContactByIdAsync(int id);
        Task<ContactInfo> AddContactAsync(ContactInfo contact);
        Task<ContactInfo?> UpdateContactAsync(int id, ContactInfo contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
