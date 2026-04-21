using ContactManagement.Models;
using ContactManagement.Services;

var service = new ContactService();

Console.WriteLine("========================================");
Console.WriteLine("  Contact Management System");
Console.WriteLine("========================================");

bool running = true;
while (running)
{
    Console.WriteLine("\n--------- MENU ---------");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View All Contacts");
    Console.WriteLine("3. Update Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("5. Find Contact by ID");
    Console.WriteLine("6. Exit");
    Console.WriteLine("------------------------");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            AddContact(service);
            break;
        case "2":
            ViewAllContacts(service);
            break;
        case "3":
            UpdateContact(service);
            break;
        case "4":
            DeleteContact(service);
            break;
        case "5":
            FindContactById(service);
            break;
        case "6":
            running = false;
            Console.WriteLine("\nGoodbye!");
            break;
        default:
            Console.WriteLine("\n[ERROR] Invalid choice. Please enter 1-6.");
            break;
    }
}

// ── Menu Actions ──────────────────────────────────────────────────────────

static void AddContact(ContactService service)
{
    Console.WriteLine("\n--- Add New Contact ---");

    Console.Write("Enter Name  : ");
    string name = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enter Email : ");
    string email = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enter Phone : ");
    string phone = Console.ReadLine()?.Trim() ?? string.Empty;

    try
    {
        service.AddContact(new Contact { Name = name, Email = email, Phone = phone });
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\n[VALIDATION ERROR] {ex.Message}");
    }
}

static void ViewAllContacts(ContactService service)
{
    Console.WriteLine("\n--- All Contacts ---");
    var contacts = service.GetAllContacts();

    if (contacts.Count == 0)
    {
        Console.WriteLine("  No contacts found.");
        return;
    }

    Console.WriteLine($"  {"ID",-5} {"Name",-20} {"Email",-30} {"Phone",-15}");
    Console.WriteLine($"  {new string('-', 72)}");
    foreach (var c in contacts)
        Console.WriteLine($"  {c.Id,-5} {c.Name,-20} {c.Email,-30} {c.Phone,-15}");
}

static void UpdateContact(ContactService service)
{
    Console.WriteLine("\n--- Update Contact ---");

    Console.Write("Enter Contact ID to update: ");
    if (!int.TryParse(Console.ReadLine()?.Trim(), out int id))
    {
        Console.WriteLine("[ERROR] Invalid ID. Please enter a number.");
        return;
    }

    Console.Write("Enter new Name  : ");
    string name = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enter new Email : ");
    string email = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enter new Phone : ");
    string phone = Console.ReadLine()?.Trim() ?? string.Empty;

    try
    {
        bool result = service.UpdateContact(id, new Contact { Name = name, Email = email, Phone = phone });
        if (!result)
            Console.WriteLine($"[ERROR] Contact with ID {id} not found.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\n[VALIDATION ERROR] {ex.Message}");
    }
}

static void DeleteContact(ContactService service)
{
    Console.WriteLine("\n--- Delete Contact ---");

    Console.Write("Enter Contact ID to delete: ");
    if (!int.TryParse(Console.ReadLine()?.Trim(), out int id))
    {
        Console.WriteLine("[ERROR] Invalid ID. Please enter a number.");
        return;
    }

    bool result = service.DeleteContact(id);
    if (!result)
        Console.WriteLine($"[ERROR] Contact with ID {id} not found.");
}

static void FindContactById(ContactService service)
{
    Console.WriteLine("\n--- Find Contact by ID ---");

    Console.Write("Enter Contact ID: ");
    if (!int.TryParse(Console.ReadLine()?.Trim(), out int id))
    {
        Console.WriteLine("[ERROR] Invalid ID. Please enter a number.");
        return;
    }

    var contact = service.GetContactById(id);
    if (contact == null)
    {
        Console.WriteLine($"[ERROR] Contact with ID {id} not found.");
        return;
    }

    Console.WriteLine($"\n  ID    : {contact.Id}");
    Console.WriteLine($"  Name  : {contact.Name}");
    Console.WriteLine($"  Email : {contact.Email}");
    Console.WriteLine($"  Phone : {contact.Phone}");
}
