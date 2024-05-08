using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcPresentation.Controllers
{
    public class EventsController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();

        ///</summary>
        ///Creator:            Matthew Baccam
        ///Created:            04/26/2024
        ///Summary:            Created the index
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/26/2024
        ///What Was Changed:   Initial creation
        ///</summary>
        // GET: Events
        public ActionResult Index()
        {
            List<EventVM> events = new List<EventVM>();
            List<Models.EventVM> eventVMs = new List<Models.EventVM>();
            try
            {
                events = _manager.EventManager.getAllEvents();
                events.ForEach(eventSelected =>
                {
                    eventVMs.Add(new Models.EventVM()
                    {
                        id = eventSelected.EventID.ToString(),
                        title = eventSelected.EventName,
                        start = eventSelected.StartTime.ToString("yyyy-MM-dd"),
                        end = eventSelected.EndTime.ToString("yyyy-MM-dd"),
                        url = $"/Events/Details?id={eventSelected.EventID}"//This will be linked to the details page
                    });
                });
            }
            catch
            {
                throw;
            }
            return View(eventVMs);
        }

        ///</summary>
        ///Creator:            Matthew Baccam
        ///Created:            04/26/2024
        ///Summary:            Created details for an event
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/26/2024
        ///What Was Changed:   Initial creation
        ///</summary>
        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            EventVM currentEvent = new EventVM();
            try
            {
                currentEvent = _manager.EventManager.SelectEventVMByID(int.Parse(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return View(currentEvent);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        public ActionResult Create(Event currentEvent)
        {
            try
            {
                _manager.EventManager.CreateEvent(currentEvent);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "An error occurred while creating the event. Please try again.");
                return View(currentEvent);
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            Event currentEvent = null;

            try
            {
                currentEvent = _manager.EventManager.SelectEventByEventID(id);
                Session["oldEvent"] = currentEvent;
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return View(currentEvent);
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Event currentEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // guess we don't need the old event? lmao
                    Event oldEvent = (Event)Session["oldEvent"];
                    _manager.EventManager.UpdateEvent(currentEvent);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Event eventToDelete)
        {
            //doesnt work lmao
            try
            {
                var foundEvent = _manager.EventManager.SelectAllEvents().FirstOrDefault(x => x.EventID == id);

                if (foundEvent == null)
                {
                    return View("Error");
                }
                else
                {
                    EventVM evVM = new EventVM();
                    evVM.EventID = foundEvent.EventID;
                    _manager.EventManager.DeleteEvent(evVM);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
