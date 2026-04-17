using ContactCachingAPI.Models;
using ContactCachingAPI.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace ContactCachingAPI.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;
    private readonly IMemoryCache _cache;
    private readonly ILogger<ContactService> _logger;

    private const string AllContactsCacheKey = "all_contacts";
    private const string ContactByIdPrefix   = "contact_";
    private static readonly TimeSpan Expiry  = TimeSpan.FromSeconds(60);

    public ContactService(IContactRepository repo, IMemoryCache cache, ILogger<ContactService> logger)
    {
        _repo   = repo;
        _cache  = cache;
        _logger = logger;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        // Try cache first
        if (_cache.TryGetValue(AllContactsCacheKey, out IEnumerable<Contact>? cached))
        {
            _logger.LogInformation("[CACHE HIT] All contacts served from cache.");
            return cached!;
        }

        // Cache miss -> go to repository
        _logger.LogInformation("[CACHE MISS] Fetching all contacts from repository...");
        var contacts = await _repo.GetAllAsync();

        _cache.Set(AllContactsCacheKey, contacts, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = Expiry,
            SlidingExpiration               = TimeSpan.FromSeconds(30)
        });
        _logger.LogInformation("[CACHE SET] All contacts cached for 60s (sliding 30s).");

        return contacts;
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        var key = $"{ContactByIdPrefix}{id}";

        if (_cache.TryGetValue(key, out Contact? cached))
        {
            _logger.LogInformation("[CACHE HIT] Contact ID={Id} served from cache.", id);
            return cached;
        }

        _logger.LogInformation("[CACHE MISS] Fetching contact ID={Id} from repository...", id);
        var contact = await _repo.GetByIdAsync(id);

        if (contact != null)
        {
            _cache.Set(key, contact, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = Expiry
            });
            _logger.LogInformation("[CACHE SET] Contact ID={Id} cached for 60s.", id);
        }

        return contact;
    }
}
