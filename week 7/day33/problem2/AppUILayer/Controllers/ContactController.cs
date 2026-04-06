using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppUILayer.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [Route("~/")]
        [Route("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [Route("Details/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetAllCompanies();
            ViewBag.Departments = _repo.GetAllDepartments();
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("Edit/{id}")]
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            ViewBag.Companies = _repo.GetAllCompanies();
            ViewBag.Departments = _repo.GetAllDepartments();
            return View(contact);
        }

        [Route("Edit/{id}")]
        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("Delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}