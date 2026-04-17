using CategoryService.DTOs;
using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services;

public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryServiceImpl(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();
        return categories.Select(ToDto);
    }

    public async Task<CategoryResponseDto?> GetByIdAsync(int id)
    {
        var category = await _repo.GetByIdAsync(id);
        return category is null ? null : ToDto(category);
    }

    public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            Description = dto.Description
        };
        var created = await _repo.AddAsync(category);
        return ToDto(created);
    }

    public async Task<CategoryResponseDto?> UpdateAsync(int id, UpdateCategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            Description = dto.Description
        };
        var updated = await _repo.UpdateAsync(id, category);
        return updated is null ? null : ToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);

    private static CategoryResponseDto ToDto(Category c) => new()
    {
        CategoryId = c.CategoryId,
        CategoryName = c.CategoryName,
        Description = c.Description
    };
}
