using Microsoft.AspNetCore.Mvc;
using WebApplication20.Models;
using WebApplication20.Services;

namespace WebApplication20.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)  
            {
                return View(contactInfo);  
            }

            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}