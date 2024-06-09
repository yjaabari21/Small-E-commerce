using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOfferservice _offerservice;
        public OffersController()
        {
            _offerservice = new Offerservice();
        }
        public ActionResult Index()
        {
            List<Offers> offers = _offerservice.GetAll().AsQueryable().OrderByDescending(x => x.Id).ToList();
            return View(offers);
        }
        public ActionResult Add() 
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            Offers detailsEntity = _offerservice.GetById(id);
            return View(detailsEntity);
        }
        public ActionResult Edit(int? id)
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            return View();
        }
        public JsonResult GetOffs() 
        {
            List<Offers> offers = _offerservice.GetAll().AsQueryable().OrderByDescending(x => x.Id).ToList();
            List<OffersModel> models = new List<OffersModel>();
            foreach (Offers offer in offers)
            {
                models.Add(
                    new OffersModel
                    {
                        Id = offer.Id,
                        ItemName = offer.Name,
                        ItemDesc = offer.Description,
                        OldPrice = offer.Price,
                        NewPrice = offer.Price/2,
                    });
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}