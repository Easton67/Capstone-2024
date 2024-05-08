using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class FundraisingController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        // GET: FundraisingEvents
        public ActionResult Index()
        {
            List<FundraisingEvent> events = new List<FundraisingEvent>();
            try
            {
                events = _manager.FundraisingEventManager.GetFundraisingEvents();
            }
            catch
            {
                throw;
            }
            return View(events);
        }

        // GET: FundraisingEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FundraisingEvents/Create
        [HttpPost]
        public ActionResult Create(FundraisingEvent fundraiser)
        {
            try
            {
                _manager.FundraisingEventManager.CreateFundraisingEvent(fundraiser);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while creating the fundraiser. Please try again.");
                return View(fundraiser);
            }
        }
    }
}