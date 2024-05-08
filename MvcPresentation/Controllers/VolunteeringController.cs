using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class VolunteeringController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        private IVolunteerManager volunteerManager = null;
        public VolunteeringController()
        {
            volunteerManager = new VolunteerManager();
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/2/2024
        /// Summary:            Functionality for the index method for viewing volunteers.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/2/2024
        /// What Was Changed:   Initial Creation
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Wrapped in try catch
        /// </summary>
        // GET: Volunteering
        public ActionResult Index()
        {
            List<VolunteerVM> volunteerVM = new List<VolunteerVM>();

            try
            {
                volunteerVM = volunteerManager.ViewVolunteers();
            }
            catch (Exception)
            {
                throw;
            }
            return View(volunteerVM);
        }

        // GET: Volunteering/Details/5
        public ActionResult Details(string id)
        {
            Volunteer volunteer = new Volunteer();
            try
            {
                volunteer = volunteerManager.RetrieveVolunteer(id);
            }
            catch (Exception)
            {
                throw;
            }
            return View(volunteer);
        }

        // GET: Volunteering/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteering/Create
        [HttpPost]
        public ActionResult Create(Volunteer volunteer)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteering/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Volunteering/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
