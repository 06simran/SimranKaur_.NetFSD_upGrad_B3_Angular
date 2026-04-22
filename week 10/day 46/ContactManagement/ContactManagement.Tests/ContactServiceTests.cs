using ContactManagement.Models;
using ContactManagement.Services;
using ContactManagement.Validators;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private static Contact ValidContact(string name = "Test User",
                                            string email = "test@example.com",
                                            string phone = "9876543210")
            => new() { Name = name, Email = email, Phone = phone };

        // ── AddContact ───────────────────────────────────────────────────

        [Fact]
        public void AddContact_ValidContact_AddsSuccessfully()
        {
            var service = new ContactService();
            service.AddContact(ValidContact());

            Assert.Single(service.GetAllContacts());
        }

        [Fact]
        public void AddContact_AssignsIncrementalId()
        {
            var service = new ContactService();
            service.AddContact(ValidContact("Alice", "alice@x.com", "1111111111"));
            service.AddContact(ValidContact("Bob",   "bob@x.com",   "2222222222"));

            var all = service.GetAllContacts();
            Assert.Equal(1, all[0].Id);
            Assert.Equal(2, all[1].Id);
        }

        [Fact]
        public void AddContact_NullContact_ThrowsArgumentNullException()
        {
            var service = new ContactService();
            Assert.Throws<ArgumentNullException>(() => service.AddContact(null!));
        }

        [Fact]
        public void AddContact_InvalidEmail_ThrowsArgumentException()
        {
            var service = new ContactService();
            var bad = new Contact { Name = "Test", Email = "not-valid", Phone = "9876543210" };
            Assert.Throws<ArgumentException>(() => service.AddContact(bad));
        }

        [Fact]
        public void AddContact_EmptyName_ThrowsArgumentException()
        {
            var service = new ContactService();
            var bad = new Contact { Name = "", Email = "a@b.com", Phone = "9876543210" };
            Assert.Throws<ArgumentException>(() => service.AddContact(bad));
        }

        // ── UpdateContact ────────────────────────────────────────────────

        [Fact]
        public void UpdateContact_ExistingId_UpdatesFields()
        {
            var service = new ContactService();
            service.AddContact(ValidContact());

            var updated = new Contact { Name = "Updated Name", Email = "up@x.com", Phone = "1234567890" };
            var result = service.UpdateContact(1, updated);

            Assert.True(result);
            var contact = service.GetContactById(1);
            Assert.Equal("Updated Name", contact?.Name);
        }

        [Fact]
        public void UpdateContact_NonExistingId_ReturnsFalse()
        {
            var service = new ContactService();
            var result = service.UpdateContact(999, ValidContact());
            Assert.False(result);
        }

        [Fact]
        public void UpdateContact_NullContact_ThrowsArgumentNullException()
        {
            var service = new ContactService();
            Assert.Throws<ArgumentNullException>(() => service.UpdateContact(1, null!));
        }

        // ── DeleteContact ────────────────────────────────────────────────

        [Fact]
        public void DeleteContact_ExistingId_RemovesContact()
        {
            var service = new ContactService();
            service.AddContact(ValidContact());

            var result = service.DeleteContact(1);

            Assert.True(result);
            Assert.Empty(service.GetAllContacts());
        }

        [Fact]
        public void DeleteContact_NonExistingId_ReturnsFalse()
        {
            var service = new ContactService();
            var result = service.DeleteContact(999);
            Assert.False(result);
        }

        // ── GetAllContacts ────────────────────────────────────────────────

        [Fact]
        public void GetAllContacts_NoContacts_ReturnsEmptyList()
        {
            var service = new ContactService();
            Assert.Empty(service.GetAllContacts());
        }

        [Fact]
        public void GetAllContacts_MultipleContacts_ReturnsAll()
        {
            var service = new ContactService();
            service.AddContact(ValidContact("Alice", "alice@x.com", "1111111111"));
            service.AddContact(ValidContact("Bob",   "bob@x.com",   "2222222222"));
            service.AddContact(ValidContact("Carol", "carol@x.com", "3333333333"));

            Assert.Equal(3, service.GetAllContacts().Count);
        }

        // ── GetContactById ────────────────────────────────────────────────

        [Fact]
        public void GetContactById_ExistingId_ReturnsContact()
        {
            var service = new ContactService();
            service.AddContact(ValidContact("Alice", "alice@x.com", "1111111111"));

            var contact = service.GetContactById(1);

            Assert.NotNull(contact);
            Assert.Equal("Alice", contact.Name);
        }

        [Fact]
        public void GetContactById_NonExistingId_ReturnsNull()
        {
            var service = new ContactService();
            Assert.Null(service.GetContactById(999));
        }
    }

    public class ContactValidatorTests
    {
        // ── Valid ────────────────────────────────────────────────────────

        [Fact]
        public void Validate_ValidContact_ReturnsNoErrors()
        {
            var contact = new Contact { Name = "Alice", Email = "alice@example.com", Phone = "9876543210" };
            var errors = ContactValidator.Validate(contact);
            Assert.Empty(errors);
        }

        // ── Name ─────────────────────────────────────────────────────────

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Validate_EmptyOrWhitespaceName_ReturnsError(string name)
        {
            var contact = new Contact { Name = name, Email = "a@b.com", Phone = "1234567890" };
            Assert.Contains(ContactValidator.Validate(contact), e => e.Contains("Name"));
        }

        [Fact]
        public void Validate_SingleCharName_ReturnsError()
        {
            var contact = new Contact { Name = "A", Email = "a@b.com", Phone = "1234567890" };
            Assert.Contains(ContactValidator.Validate(contact), e => e.Contains("Name"));
        }

        // ── Email ─────────────────────────────────────────────────────────

        [Theory]
        [InlineData("notanemail")]
        [InlineData("missing@tld")]
        [InlineData("@nodomain.com")]
        public void Validate_InvalidEmail_ReturnsError(string email)
        {
            var contact = new Contact { Name = "Alice", Email = email, Phone = "9876543210" };
            Assert.Contains(ContactValidator.Validate(contact), e => e.Contains("Email"));
        }

        // ── Phone ─────────────────────────────────────────────────────────

        [Theory]
        [InlineData("abc")]
        [InlineData("123")]
        [InlineData("!@#$%")]
        public void Validate_InvalidPhone_ReturnsError(string phone)
        {
            var contact = new Contact { Name = "Alice", Email = "a@b.com", Phone = phone };
            Assert.Contains(ContactValidator.Validate(contact), e => e.Contains("Phone"));
        }

        [Fact]
        public void Validate_NullContact_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ContactValidator.Validate(null!));
        }
    }
}
