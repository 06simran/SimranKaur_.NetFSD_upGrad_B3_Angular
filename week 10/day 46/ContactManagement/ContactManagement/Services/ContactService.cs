using ContactManagement.Interfaces;
using ContactManagement.Models;
using ContactManagement.Validators;

namespace ContactManagement.Services
{
    /// <summary>
    /// In-memory implementation of <see cref="IContactService"/>.
    /// Manages a collection of contacts using a List as the backing store.
    /// </summary>
    internal class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        private int _nextId = 1;

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Thrown when contact is null.</exception>
        /// <exception cref="ArgumentException">Thrown when contact data is invalid.</exception>
        public void AddContact(Contact contact)
        {
            // CA1510 fix: use ArgumentNullException.ThrowIfNull instead of manual null check + throw
            ArgumentNullException.ThrowIfNull(contact);

            EnsureContactIsValid(contact);

            contact.Id = _nextId++;
            _contacts.Add(contact);

            Console.WriteLine($"[ADD] Contact '{contact.Name}' added with ID {contact.Id}.");
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Thrown when updatedContact is null.</exception>
        /// <exception cref="ArgumentException">Thrown when updatedContact data is invalid.</exception>
        public bool UpdateContact(int id, Contact updatedContact)
        {
            // CA1510 fix: use ArgumentNullException.ThrowIfNull instead of manual null check + throw
            ArgumentNullException.ThrowIfNull(updatedContact);

            EnsureContactIsValid(updatedContact);

            var existing = FindById(id);
            if (existing == null)
            {
                Console.WriteLine($"[UPDATE] Contact with ID {id} not found.");
                return false;
            }

            existing.Name = updatedContact.Name;
            existing.Email = updatedContact.Email;
            existing.Phone = updatedContact.Phone;

            Console.WriteLine($"[UPDATE] Contact ID {id} updated successfully.");
            return true;
        }

        /// <inheritdoc/>
        public bool DeleteContact(int id)
        {
            var contact = FindById(id);
            if (contact == null)
            {
                Console.WriteLine($"[DELETE] Contact with ID {id} not found.");
                return false;
            }

            _contacts.Remove(contact);
            Console.WriteLine($"[DELETE] Contact '{contact.Name}' (ID {id}) deleted.");
            return true;
        }

        /// <inheritdoc/>
        public IReadOnlyList<Contact> GetAllContacts()
        {
            return _contacts.AsReadOnly();
        }

        /// <inheritdoc/>
        public Contact? GetContactById(int id) => FindById(id);

        // ── Private Helpers ──────────────────────────────────────────────────

        /// <summary>
        /// Finds a contact by ID. Returns null if not found.
        /// Extracted to avoid duplicate lookup logic (DRY principle).
        /// </summary>
        private Contact? FindById(int id)
            => _contacts.FirstOrDefault(c => c.Id == id);

        /// <summary>
        /// Validates a contact and throws if invalid.
        /// Centralises validation so Add and Update share the same rules.
        /// </summary>
        private static void EnsureContactIsValid(Contact contact)
        {
            var errors = ContactValidator.Validate(contact);
            if (errors.Count > 0)
                throw new ArgumentException($"Invalid contact data:\n  - {string.Join("\n  - ", errors)}");
        }
    }
}
