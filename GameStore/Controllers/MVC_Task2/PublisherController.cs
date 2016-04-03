using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Models;

namespace GameStore.Controllers.MVC_Task2
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        //
        // GET: /Publisher/

        public ActionResult Publisher(string companyName)
        {
            PublisherWebModel publisher = Mapper.Map<PublisherWebModel>( _publisherService.GetPuplisherByCompanyName(companyName));
            return View(publisher);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(PublisherWebModel publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            _publisherService.AddNewPublisher(Mapper.Map<PublisherWebModel, PublisherBLModel>(publisher));

            return RedirectToAction("Publisher", new {companyName = publisher.CompanyName});
        }

    }
}
