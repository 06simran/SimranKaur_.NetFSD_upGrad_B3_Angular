using ContactWebAPI.Interfaces;
using ContactWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers
{
    /// <summary>
    /// ContactsController — exposes CRUD endpoints for Contact Management.
    ///
    /// DEBUGGING GUIDE (Visual Studio):
    ///   Set breakpoints on any action method.
    ///   Use F11 (Step Into) to trace into repository methods.
    ///   Use Locals / Watch window to inspect 'contact', 'id', 'result' variables.
    ///   Use Exception Settings (Debug > Windows > Exception Settings) to catch all CLR exceptions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactRepository repository, ILogger<ContactsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // ── GET /api/contacts ─────────────────────────────────────────────
        /// <summary>Returns all contacts.</summary>
        /// <remarks>
        /// Postman test:
        ///   GET http://localhost:5000/api/contacts
        ///   Expected: 200 OK, array of contacts
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<Contact>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            // ← SET BREAKPOINT HERE to inspect returned contacts list
            var contacts = await _repository.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Contact>>.Ok(contacts, "Contacts retrieved successfully."));
        }

        // ── GET /api/contacts/{id} ────────────────────────────────────────
        /// <summary>Returns a single contact by ID.</summary>
        /// <remarks>
        /// Postman test:
        ///   GET http://localhost:5000/api/contacts/1  → 200 OK
        ///   GET http://localhost:5000/api/contacts/99 → 404 Not Found
        /// </remarks>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            // ← SET BREAKPOINT HERE — hover over 'id' to verify it binds correctly
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null)
            {
                _logger.LogWarning("GET /api/contacts/{Id} returned 404.", id);
                return NotFound(ApiResponse<Contact>.Fail($"Contact with ID {id} not found."));
            }

            return Ok(ApiResponse<Contact>.Ok(contact));
        }

        // ── POST /api/contacts ────────────────────────────────────────────
        /// <summary>Creates a new contact.</summary>
        /// <remarks>
        /// Postman test:
        ///   POST http://localhost:5000/api/contacts
        ///   Headers: Content-Type: application/json
        ///   Body (raw JSON):
        ///   {
        ///     "name": "David Lee",
        ///     "email": "david@example.com",
        ///     "phone": "9001234567"
        ///   }
        ///   Expected: 201 Created
        ///
        /// Common Postman errors to debug:
        ///   - 415 Unsupported Media Type → Missing Content-Type header
        ///   - 400 Bad Request            → Invalid JSON or validation error
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            // ← SET BREAKPOINT HERE — inspect ModelState.IsValid and 'contact' fields
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                _logger.LogWarning("POST /api/contacts — validation failed: {Errors}", string.Join(", ", errors));
                return BadRequest(ApiResponse<Contact>.Fail(string.Join("; ", errors)));
            }

            var created = await _repository.AddAsync(contact);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                ApiResponse<Contact>.Ok(created, "Contact created successfully."));
        }

        // ── PUT /api/contacts/{id} ────────────────────────────────────────
        /// <summary>Updates an existing contact.</summary>
        /// <remarks>
        /// Postman test:
        ///   PUT http://localhost:5000/api/contacts/1
        ///   Headers: Content-Type: application/json
        ///   Body (raw JSON):
        ///   {
        ///     "name": "Alice Updated",
        ///     "email": "alice.new@example.com",
        ///     "phone": "1122334455"
        ///   }
        ///   Expected: 200 OK
        /// </remarks>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<Contact>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(ApiResponse<Contact>.Fail(string.Join("; ", errors)));
            }

            // ← SET BREAKPOINT HERE — use Watch window to track 'id' and 'contact.Name'
            var updated = await _repository.UpdateAsync(id, contact);
            if (updated == null)
                return NotFound(ApiResponse<Contact>.Fail($"Contact with ID {id} not found."));

            return Ok(ApiResponse<Contact>.Ok(updated, "Contact updated successfully."));
        }

        // ── DELETE /api/contacts/{id} ─────────────────────────────────────
        /// <summary>Deletes a contact by ID.</summary>
        /// <remarks>
        /// Postman test:
        ///   DELETE http://localhost:5000/api/contacts/1
        ///   Expected: 200 OK
        ///   DELETE http://localhost:5000/api/contacts/99
        ///   Expected: 404 Not Found
        /// </remarks>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<bool>.Fail($"Contact with ID {id} not found."));

            return Ok(ApiResponse<bool>.Ok(true, $"Contact ID {id} deleted successfully."));
        }
    }
}
