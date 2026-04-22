using ContactManagement.Models;
using System.Text.RegularExpressions;

namespace ContactManagement.Validators
{
    /// <summary>
    /// Provides validation logic for Contact entities.
    /// Follows Single Responsibility Principle — validation is isolated here.
    /// </summary>
    internal static class ContactValidator
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 100;
        private const int MaxEmailLength = 254;
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private const string PhonePattern = @"^\+?[\d\s\-\(\)]{7,15}$";

        /// <summary>
        /// Validates a contact and returns a list of validation error messages.
        /// </summary>
        /// <param name="contact">The contact to validate.</param>
        /// <returns>A list of error messages. Empty list means valid.</returns>
        public static IList<string> Validate(Contact contact)
        {
            // CA1510 fix: use ArgumentNullException.ThrowIfNull instead of manual throw
            ArgumentNullException.ThrowIfNull(contact);

            var errors = new List<string>();

            ValidateName(contact.Name, errors);
            ValidateEmail(contact.Email, errors);
            ValidatePhone(contact.Phone, errors);

            return errors;
        }

        /// <summary>Returns true if the contact passes all validation rules.</summary>
        public static bool IsValid(Contact contact) => Validate(contact).Count == 0;

        // CA1859 fix: use concrete List<string> instead of IList<string> for better performance
        private static void ValidateName(string name, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Name is required.");
                return;
            }

            if (name.Length < MinNameLength || name.Length > MaxNameLength)
                errors.Add($"Name must be between {MinNameLength} and {MaxNameLength} characters.");
        }

        // CA1859 fix: use concrete List<string> instead of IList<string> for better performance
        private static void ValidateEmail(string email, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add("Email is required.");
                return;
            }

            if (email.Length > MaxEmailLength)
                errors.Add($"Email must not exceed {MaxEmailLength} characters.");

            if (!Regex.IsMatch(email, EmailPattern))
                errors.Add("Email format is invalid.");
        }

        // CA1859 fix: use concrete List<string> instead of IList<string> for better performance
        private static void ValidatePhone(string phone, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                errors.Add("Phone is required.");
                return;
            }

            if (!Regex.IsMatch(phone, PhonePattern))
                errors.Add("Phone format is invalid. Use digits, spaces, dashes, or parentheses (7–15 digits).");
        }
    }
}
