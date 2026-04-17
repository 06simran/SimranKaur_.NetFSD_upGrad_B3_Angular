using ContactService.DTOs;

namespace ContactService.Services;

public interface IContactService
{
    Task<IEnumerable<ContactResponseDto>> GetAllAsync();
    Task<ContactResponseDto?> GetByIdAsync(int id);
    Task<ContactResponseDto> CreateAsync(CreateContactDto dto);
    Task<ContactResponseDto?> UpdateAsync(int id, UpdateContactDto dto);
    Task<bool> DeleteAsync(int id);
}
