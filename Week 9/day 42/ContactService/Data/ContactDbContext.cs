using Microsoft.EntityFrameworkCore;
using ContactService.Models;

namespace ContactService.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(e =>
        {
            e.HasKey(c => c.ContactId);
            e.Property(c => c.Name).IsRequired().HasMaxLength(150);
            e.Property(c => c.Email).IsRequired().HasMaxLength(200);
            e.Property(c => c.Phone).HasMaxLength(20);
        });
    }
}
