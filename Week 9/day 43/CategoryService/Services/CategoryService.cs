using CategoryService.Models;
using CategoryService.Repository;

namespace CategoryService.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category> AddAsync(Category category);
    Task<Category?> UpdateAsync(int id, Category category);
    Task<bool> DeleteAsync(int id);
}

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Category>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Category?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Category> AddAsync(Category category) => _repo.AddAsync(category);
    public Task<Category?> UpdateAsync(int id, Category category) => _repo.UpdateAsync(id, category);
    public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
}
