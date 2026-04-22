using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ContactWebAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ContactWebAPI.Tests
{
    /// <summary>
    /// Integration tests that spin up the real API in-process and send HTTP requests.
    /// These mirror exactly what you would do in Postman.
    /// Run: dotnet test
    /// </summary>
    public class ContactsApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public ContactsApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // ── GET /api/contacts ─────────────────────────────────────────────

        [Fact]
        public async Task GetAll_Returns200WithContacts()
        {
            var response = await _client.GetAsync("/api/contacts");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            Assert.Contains("Alice", body);
        }

        // ── GET /api/contacts/{id} ────────────────────────────────────────

        [Fact]
        public async Task GetById_ExistingId_Returns200()
        {
            var response = await _client.GetAsync("/api/contacts/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_NonExistingId_Returns404()
        {
            var response = await _client.GetAsync("/api/contacts/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // ── POST /api/contacts ────────────────────────────────────────────

        [Fact]
        public async Task Create_ValidContact_Returns201()
        {
            var newContact = new { name = "David Lee", email = "david@example.com", phone = "9001234567" };
            var content = JsonContent.Create(newContact);

            var response = await _client.PostAsync("/api/contacts", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            Assert.Contains("David Lee", body);
        }

        [Fact]
        public async Task Create_MissingName_Returns400()
        {
            var badContact = new { name = "", email = "x@x.com", phone = "9876543210" };
            var content = JsonContent.Create(badContact);

            var response = await _client.PostAsync("/api/contacts", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_InvalidEmail_Returns400()
        {
            var badContact = new { name = "Test", email = "not-an-email", phone = "9876543210" };
            var content = JsonContent.Create(badContact);

            var response = await _client.PostAsync("/api/contacts", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_MissingContentTypeHeader_Returns415()
        {
            // Simulates the common Postman mistake of not setting Content-Type
            var content = new StringContent("{\"name\":\"Test\"}", Encoding.UTF8); // no media type
            var response = await _client.PostAsync("/api/contacts", content);

            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        // ── PUT /api/contacts/{id} ────────────────────────────────────────

        [Fact]
        public async Task Update_ExistingId_Returns200()
        {
            var updated = new { name = "Alice Updated", email = "alice.new@example.com", phone = "1122334455" };
            var content = JsonContent.Create(updated);

            var response = await _client.PutAsync("/api/contacts/1", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            Assert.Contains("Alice Updated", body);
        }

        [Fact]
        public async Task Update_NonExistingId_Returns404()
        {
            var updated = new { name = "Ghost", email = "ghost@x.com", phone = "9876543210" };
            var content = JsonContent.Create(updated);

            var response = await _client.PutAsync("/api/contacts/9999", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // ── DELETE /api/contacts/{id} ─────────────────────────────────────

        [Fact]
        public async Task Delete_ExistingId_Returns200()
        {
            // First add a contact to delete
            var newContact = new { name = "Temp User", email = "temp@x.com", phone = "9876543210" };
            var createResponse = await _client.PostAsync("/api/contacts", JsonContent.Create(newContact));
            var body = await createResponse.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(body);
            var id = doc.RootElement.GetProperty("data").GetProperty("id").GetInt32();

            var deleteResponse = await _client.DeleteAsync($"/api/contacts/{id}");
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task Delete_NonExistingId_Returns404()
        {
            var response = await _client.DeleteAsync("/api/contacts/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
