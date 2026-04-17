using ContactCachingAPI.Models;

namespace ContactCachingAPI.Repository;

// Simulates a database using in-memory collection
public class ContactRepository : IContactRepository
{
    private static readonly List<Contact> _contacts = new()
    {
        new Contact { ContactId = 1, Name = "Alice Johnson", Email = "alice@test.com", Phone = "9000000001" },
        new Contact { ContactId = 2, Name = "Bob Smith",     Email = "bob@test.com",   Phone = "9000000002" },
        new Contact { ContactId = 3, Name = "Carol White",   Email = "carol@test.com", Phone = "9000000003" },
        new Contact { ContactId = 4, Name = "David Brown",   Email = "david@test.com", Phone = "9000000004" },
        new Contact { ContactId = 5, Name = "Eve Davis",     Email = "eve@test.com",   Phone = "9000000005" },
    };

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        await Task.Delay(100); // Simulate DB latency
        Console.WriteLine("[REPOSITORY] Fetching ALL contacts from data source...");
        return _contacts;
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        await Task.Delay(50);
        Console.WriteLine($"[REPOSITORY] Fetching contact ID={id} from data source...");
        return _contacts.FirstOrDefault(c => c.ContactId == id);
    }
}
