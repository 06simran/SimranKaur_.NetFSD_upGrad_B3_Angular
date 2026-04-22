using ContactManagement.Models;

namespace ContactManagement.Interfaces
{
    /// <summary>
    /// Defines the contract for contact management operations.
    /// </summary>
    internal interface IContactService
    {
        /// <summary>Adds a new contact to the system.</summary>
        /// <param name="contact">The contact to add.</param>
        void AddContact(Contact contact);

        /// <summary>Updates an existing contact's details.</summary>
        /// <param name="id">The ID of the contact to update.</param>
        /// <param name="updatedContact">The updated contact data.</param>
        /// <returns>True if the update was successful; otherwise false.</returns>
        bool UpdateContact(int id, Contact updatedContact);

        /// <summary>Deletes a contact by ID.</summary>
        /// <param name="id">The ID of the contact to delete.</param>
        /// <returns>True if the deletion was successful; otherwise false.</returns>
        bool DeleteContact(int id);

        /// <summary>Retrieves all contacts in the system.</summary>
        /// <returns>A read-only list of all contacts.</returns>
        IReadOnlyList<Contact> GetAllContacts();

        /// <summary>Retrieves a single contact by ID.</summary>
        /// <param name="id">The ID of the contact to retrieve.</param>
        /// <returns>The contact if found; otherwise null.</returns>
        Contact? GetContactById(int id);
    }
}
