using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using MvcPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class AppointmentsController : Controller
    {
        private MainManager _manager;
        public AppointmentsController()
        {
            _manager = MainManager.GetMainManager();
        }

        // GET: Appointments
        public ActionResult Index()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                var email = User.Identity.GetUserName();
                if (User.IsInRole("Admin"))
                {
                    appointments = _manager.AppointmentManager.GetAllAppointments();
                }
                else
                {
                    appointments = _manager.AppointmentManager.GetAllAppointments().Where(a => a._clientID.Equals(email)).ToList();
                }
            }
            catch
            {
                throw;
            }
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            Appointment appointment = new Appointment();

            try
            {
                appointment = _manager.AppointmentManager.GetAllAppointments().FirstOrDefault(x => x._appointmentID == id);
            }
            catch
            {
                throw;
            }

            return View(appointment);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/27/2024
        /// Summary: The Get Create Appointment Method.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 04/02/2024
        /// What Was Changed: Cleaned up some logic
        /// </summary>
        // GET: Appointments/Create
        public ActionResult Create()
        {
            try
            {
                var clientIDs = _manager.UserManager.GetAllClients()
                    .Select(c => new SelectListItem { Value = c.UserID, Text = c.UserID }).ToList();
                ViewBag.clientIds = clientIDs;

                var locationIDs = _manager.LocationManager.GetLocations()
                    .Select(l => new SelectListItem { Value = l.LocationName, Text = l.LocationName }).ToList();
                ViewBag.locationNames = locationIDs;

                var types = new List<string>() { "Regular", "Checkup", "Consultation", "Follow-up", "Introduction" };
                ViewBag.appointmentTypes = types.Select(f => new SelectListItem() { Value = f, Text = f });

                ViewBag.employeeIds = _manager.UserManager.SelectAllEmployees()
                    .Select(e => new SelectListItem { Value = e.EmployeeID, Text = e.EmployeeID }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return View(new AppointmentVM());
        }


        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/27/2024
        /// Summary: The HttpPost Create Appointment Method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/27/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        // POST: Appointments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            for (int i = 1; i < 7; i++)
            {
                if (!(collection[i].Length > 0))
                {
                    ViewBag.errorMessage = "Check your inputs";
                    return View();
                }
            }
            AppointmentVM appointmentVM = new AppointmentVM();
            appointmentVM._clientID = collection[1];
            appointmentVM._locationName = collection[2];
            List<Appointment> appointments = _manager.AppointmentManager.GetAllAppointments();
            List<Location> locations = _manager.LocationManager.GetLocations();
            appointmentVM._locationId = locations.FirstOrDefault(item => item.LocationName == appointmentVM._locationName).LocationID;
            appointmentVM._appointmentType = collection[3];
            appointmentVM._appointmentStartTime = DateTime.Parse(collection[4]);
            appointmentVM._appointmentEndTime = DateTime.Parse(collection[5]);
            appointmentVM._employeeID = collection[6];
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(appointmentVM);
                }
                _manager.AppointmentManager.CreateAppointment(appointmentVM);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Appointments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Appointment appt)
        {
            try
            {
                Appointment appointment = _manager.AppointmentManager.GetAllAppointments().FirstOrDefault(a => a._appointmentID == id);
                if(appointment == null)
                {
                    return View("Error");
                }
                else
                {
                    _manager.AppointmentManager.RemoveAppointment(appointment);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Reschedule(int id, Appointment appt)
        {
            try
            {
                Appointment appointment = _manager.AppointmentManager.GetAllAppointments().FirstOrDefault(a => a._appointmentID == id);
                if (appointment == null)
                {
                    return View("Error");
                }
                else
                {
                    _manager.AppointmentManager.RemoveAppointment(appointment);
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
