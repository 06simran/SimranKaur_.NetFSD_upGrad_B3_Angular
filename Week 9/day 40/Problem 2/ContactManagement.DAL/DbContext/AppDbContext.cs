using ContactManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.DAL.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ContactInfo> Contacts { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<UserInfo> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One Company -> Many Contacts
        modelBuilder.Entity<ContactInfo>()
            .HasOne(c => c.Company)
            .WithMany(co => co.Contacts)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // One Department -> Many Contacts
        modelBuilder.Entity<ContactInfo>()
            .HasOne(c => c.Department)
            .WithMany(d => d.Contacts)
            .HasForeignKey(c => c.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Data
        modelBuilder.Entity<Company>().HasData(
            new Company { CompanyId = 1, CompanyName = "TechCorp" },
            new Company { CompanyId = 2, CompanyName = "SoftSolutions" }
        );
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, DepartmentName = "Engineering" },
            new Department { DepartmentId = 2, DepartmentName = "HR" }
        );
    }
}
