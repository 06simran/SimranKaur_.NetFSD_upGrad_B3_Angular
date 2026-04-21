namespace ContactManagement.Models
{
    /// <summary>
    /// Represents a contact in the contact management system.
    /// </summary>
    internal class Contact
    {
        /// <summary>Gets or sets the unique identifier for the contact.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the full name of the contact.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Gets or sets the email address of the contact.</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Gets or sets the phone number of the contact.</summary>
        public string Phone { get; set; } = string.Empty;
    }
}
