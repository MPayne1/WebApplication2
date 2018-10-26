using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public DataContext db;

        public HomeController(DataContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("IndexWithForm");
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("ContactList");
            }
            return View("IndexWithForm");
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            ContactListViewModel contactListViewModel = new ContactListViewModel();

            contactListViewModel.Contacts = db.Contacts.ToList<Contact>();
            contactListViewModel.NumberOfContacts = db.Contacts.Count();

            return View(contactListViewModel);
        }
    }
}