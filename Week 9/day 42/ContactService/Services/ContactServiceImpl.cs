using ContactService.DTOs;
using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services;

public class ContactServiceImpl : IContactService
{
    private readonly IContactRepository _repo;

    public ContactServiceImpl(IContactRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ContactResponseDto>> GetAllAsync()
    {
        var contacts = await _repo.GetAllAsync();
        return contacts.Select(ToDto);
    }

    public async Task<ContactResponseDto?> GetByIdAsync(int id)
    {
        var contact = await _repo.GetByIdAsync(id);
        return contact is null ? null : ToDto(contact);
    }

    public async Task<ContactResponseDto> CreateAsync(CreateContactDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            CategoryId = dto.CategoryId
        };
        var created = await _repo.AddAsync(contact);
        return ToDto(created);
    }

    public async Task<ContactResponseDto?> UpdateAsync(int id, UpdateContactDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            CategoryId = dto.CategoryId
        };
        var updated = await _repo.UpdateAsync(id, contact);
        return updated is null ? null : ToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);

    private static ContactResponseDto ToDto(Contact c) => new()
    {
        ContactId = c.ContactId,
        Name = c.Name,
        Email = c.Email,
        Phone = c.Phone,
        CategoryId = c.CategoryId
    };
}
