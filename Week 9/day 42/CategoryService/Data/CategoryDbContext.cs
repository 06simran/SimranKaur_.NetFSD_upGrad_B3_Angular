using Microsoft.EntityFrameworkCore;
using CategoryService.Models;

namespace CategoryService.Data;

public class CategoryDbContext : DbContext
{
    public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(e =>
        {
            e.HasKey(c => c.CategoryId);
            e.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            e.Property(c => c.Description).HasMaxLength(500);
        });
    }
}
