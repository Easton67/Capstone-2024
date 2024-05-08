using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class SecurityController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();

        // GET: Security
        public ActionResult Index()
        {
            List<Incident> incidents = new List<Incident>();
            try
            {
                var email = User.Identity.GetUserName();
                if(User.IsInRole("Admin"))
                {
                    incidents = _manager.IncidentManager.SelectAllIncidents();
                }
                else
                {
                    incidents = _manager.IncidentManager.SelectAllIncidents().Where(x => x.reportedBy == email).ToList();
                }
            }
            catch
            {
                throw;
            }
            return View(incidents);
        }

        // GET: Security/Details/5
        public ActionResult Details(int incidentID)
        {
            Incident incident = new Incident();
            try
            {
                incident = _manager.IncidentManager.SelectAllIncidents().FirstOrDefault(i => i.incidentID == incidentID);
            }
            catch
            {
                throw;
            }
            return View(incident);
        }

        // GET: Security/Create
        public ActionResult Create()
        {
            return View();
        }

        private void dropdowns() 
        {
            ViewBag.IncidentStatuses =  new List<string> { "Processing", "Handled" };
        }

        // POST: Security/Create
        [HttpPost]
        public ActionResult Create(Incident incident)
        {
            try
            {
                incident.incidentStatus = "Unviewed";
                incident.feedBack = "Unviewed";
                incident.reportedBy = User.Identity.GetUserName();
                _manager.IncidentManager.AddIncident(incident.description, 
                    incident.reported, incident.reportedBy, incident.severity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Edit/5
        public ActionResult Edit(int id)
        {
            Incident incident = new Incident();
            try
            {
                incident = _manager.IncidentManager.SelectAllIncidents().FirstOrDefault(x => x.incidentID == id);
            }
            catch (Exception)
            {
                throw;
            }
            dropdowns();
            return View(incident);
        }

        // POST: Security/Edit/5
        [HttpPost]
        public ActionResult Edit(Incident incident)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    //incident.incidentStatus = "Unviewed";
                    //incident.reportedBy = User.Identity.GetUserName();
                    // updateIncident
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
