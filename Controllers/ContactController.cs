using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IOfferservice _offerservice;
        public ContactController()
        {
            _contactService = new ContactService();
            _offerservice = new Offerservice();
        }
        public ActionResult Index()
        {
            List<Contact> contactsEntity = _contactService.GetAll().AsQueryable().ToList();
            return View(contactsEntity);
        }
        public ActionResult Details(int? id)
        {
            //List<Offers> detailsEntity = _offerservice.GetById(id);
            //return View(detailsEntity);
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult GetContact()
        {
            List<Contact> contacts = _contactService.GetAll().AsQueryable().OrderByDescending(x => x.Id).ToList();
            List<ContactModel> contactModels = new List<ContactModel>();
            foreach (Contact contact in contacts)
            {
                contactModels.Add(
                    new ContactModel {
                        Id = contact.Id,
                        City = contact.City,
                        Country = contact.Country,
                        Email = contact.Email,
                        Mobile = contact.Phone,
                    });
            }
            return Json(contactModels, JsonRequestBehavior.AllowGet);
        }
    }
}