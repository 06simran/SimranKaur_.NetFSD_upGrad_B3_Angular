using ContactWebAPI.Interfaces;
using ContactWebAPI.Models;

namespace ContactWebAPI.Services
{
    /// <summary>
    /// In-memory implementation of IContactRepository.
    /// No database required — uses a List as the backing store.
    /// Registered as Singleton in DI so state persists across requests.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();
        private int _nextId = 1;
        private readonly ILogger<ContactRepository> _logger;

        public ContactRepository(ILogger<ContactRepository> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all contacts. Count: {Count}", _contacts.Count);
            return Task.FromResult<IEnumerable<Contact>>(_contacts.ToList());
        }

        public Task<Contact?> GetByIdAsync(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                _logger.LogWarning("Contact with ID {Id} not found.", id);
            else
                _logger.LogInformation("Contact found: {Name} (ID {Id})", contact.Name, id);

            return Task.FromResult(contact);
        }

        public Task<Contact> AddAsync(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));

            contact.Id = _nextId++;
            _contacts.Add(contact);
            _logger.LogInformation("Contact added: {Name} (ID {Id})", contact.Name, contact.Id);
            return Task.FromResult(contact);
        }

        public Task<Contact?> UpdateAsync(int id, Contact updatedContact)
        {
            if (updatedContact == null) throw new ArgumentNullException(nameof(updatedContact));

            var existing = _contacts.FirstOrDefault(c => c.Id == id);
            if (existing == null)
            {
                _logger.LogWarning("Update failed — contact ID {Id} not found.", id);
                return Task.FromResult<Contact?>(null);
            }

            existing.Name  = updatedContact.Name;
            existing.Email = updatedContact.Email;
            existing.Phone = updatedContact.Phone;

            _logger.LogInformation("Contact updated: ID {Id}", id);
            return Task.FromResult<Contact?>(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                _logger.LogWarning("Delete failed — contact ID {Id} not found.", id);
                return Task.FromResult(false);
            }

            _contacts.Remove(contact);
            _logger.LogInformation("Contact deleted: {Name} (ID {Id})", contact.Name, id);
            return Task.FromResult(true);
        }

    }
}
