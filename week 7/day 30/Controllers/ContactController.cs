using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "John", LastName = "Doe", CompanyName = "ABC", EmailId="john@gmail.com", MobileNo=9876543210, Designation="Manager" },
            new ContactInfo { ContactId = 2, FirstName = "Jane", LastName = "Smith", CompanyName = "XYZ", EmailId="jane@gmail.com", MobileNo=9123456780, Designation="Developer" }
        };

        // SHOW ALL
        public IActionResult ShowContacts()
        {
            var list = from c in contacts
                       select c;

            return View(list.ToList());
        }

        // ADD CONTACT
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo obj)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(obj);
                return RedirectToAction("ShowContacts");
            }
            return View(obj);
        }

        // SEARCH BY ID
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int id)
        {
            var result = from c in contacts
                         where c.ContactId == id
                         select c;

            return View("SearchResult", result.ToList());
        }

        // GET BY ID 
        public IActionResult GetContactById(int id)
        {
            var contact = (from c in contacts
                           where c.ContactId == id
                           select c).FirstOrDefault();

            return View(contact);
        }
    }
}