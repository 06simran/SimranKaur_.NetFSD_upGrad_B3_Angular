using ContactPagingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactPagingAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed 10 sample contacts for testing pagination
        modelBuilder.Entity<Contact>().HasData(
            new Contact { ContactId = 1,  Name = "Alice Johnson",   Email = "alice@test.com",   Phone = "9000000001" },
            new Contact { ContactId = 2,  Name = "Bob Smith",       Email = "bob@test.com",     Phone = "9000000002" },
            new Contact { ContactId = 3,  Name = "Carol White",     Email = "carol@test.com",   Phone = "9000000003" },
            new Contact { ContactId = 4,  Name = "David Brown",     Email = "david@test.com",   Phone = "9000000004" },
            new Contact { ContactId = 5,  Name = "Eve Davis",       Email = "eve@test.com",     Phone = "9000000005" },
            new Contact { ContactId = 6,  Name = "Frank Miller",    Email = "frank@test.com",   Phone = "9000000006" },
            new Contact { ContactId = 7,  Name = "Grace Wilson",    Email = "grace@test.com",   Phone = "9000000007" },
            new Contact { ContactId = 8,  Name = "Henry Moore",     Email = "henry@test.com",   Phone = "9000000008" },
            new Contact { ContactId = 9,  Name = "Iris Taylor",     Email = "iris@test.com",    Phone = "9000000009" },
            new Contact { ContactId = 10, Name = "Jack Anderson",   Email = "jack@test.com",    Phone = "9000000010" }
        );
    }
}
