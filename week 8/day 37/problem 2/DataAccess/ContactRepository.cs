using WebApplication2.Models;

namespace WebApplication2.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        // Static in-memory list — shared across all requests
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Alice",   LastName = "Smith",   EmailId = "alice@example.com",   MobileNo = 9876543210, Designation = "Engineer",   CompanyId = 1, DepartmentId = 1 },
            new ContactInfo { ContactId = 2, FirstName = "Bob",     LastName = "Johnson", EmailId = "bob@example.com",     MobileNo = 9123456780, Designation = "Manager",    CompanyId = 1, DepartmentId = 2 },
            new ContactInfo { ContactId = 3, FirstName = "Charlie", LastName = "Brown",   EmailId = "charlie@example.com", MobileNo = 9988776655, Designation = "Analyst",    CompanyId = 2, DepartmentId = 1 }
        };

        // Auto-increment helper
        private static int NextId() =>
            contacts.Count == 0 ? 1 : contacts.Max(c => c.ContactId) + 1;

        public Task<IEnumerable<ContactInfo>> GetAllContactsAsync()
        {
            return Task.FromResult<IEnumerable<ContactInfo>>(contacts);
        }

        public Task<ContactInfo?> GetContactByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return Task.FromResult(contact);
        }

        public Task<ContactInfo> AddContactAsync(ContactInfo contact)
        {
            contact.ContactId = NextId();
            contacts.Add(contact);
            return Task.FromResult(contact);
        }

        public Task<ContactInfo?> UpdateContactAsync(int id, ContactInfo updated)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);
            if (existing == null)
                return Task.FromResult<ContactInfo?>(null);

            existing.FirstName    = updated.FirstName;
            existing.LastName     = updated.LastName;
            existing.EmailId      = updated.EmailId;
            existing.MobileNo     = updated.MobileNo;
            existing.Designation  = updated.Designation;
            existing.CompanyId    = updated.CompanyId;
            existing.DepartmentId = updated.DepartmentId;

            return Task.FromResult<ContactInfo?>(existing);
        }

        public Task<bool> DeleteContactAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
                return Task.FromResult(false);

            contacts.Remove(contact);
            return Task.FromResult(true);
        }
    }
}
