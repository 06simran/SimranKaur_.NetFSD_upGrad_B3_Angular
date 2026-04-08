using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET /api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repository.GetAllContactsAsync();
            return Ok(contacts);
        }

        // GET /api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repository.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(contact);
        }

        // POST /api/contacts
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactInfo contact)
        {
            if (contact == null)
                return BadRequest(new { message = "Contact data is required." });

            if (string.IsNullOrWhiteSpace(contact.FirstName))
                return BadRequest(new { message = "FirstName is required." });

            if (string.IsNullOrWhiteSpace(contact.EmailId))
                return BadRequest(new { message = "EmailId is required." });

            var created = await _repository.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
        }

        // PUT /api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            if (contact == null)
                return BadRequest(new { message = "Contact data is required." });

            var updated = await _repository.UpdateContactAsync(id, contact);
            if (updated == null)
                return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(updated);
        }

        // DELETE /api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteContactAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(new { message = $"Contact with ID {id} deleted successfully." });
        }
    }
}
