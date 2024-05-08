using DataObjects;
using LogicLayer;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class VisitationsController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        // GET: Visitations
        public ActionResult Index()
        {
            List<Visit> visits = new List<Visit>();

            try
            { 
                visits = _manager.VisitManager.SelectVisitWithFromTo(DateTime.Parse("1900-01-01"), DateTime.Now);
            }
            catch
            {

                throw;
            }

            return View(visits);
        }

        // GET: Visitations/Details/5
        public ActionResult Details(int id)
        {
            Visit visit = new Visit();

            try
            {
                visit = _manager.VisitManager.SelectVisitWithFromTo(DateTime.Parse("1900-01-01"), DateTime.Now)
                                              .FirstOrDefault(x => x.VisitID == id);
            }
            catch
            {
                throw;
            }

            return View(visit);
        }

        // GET: Visitations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitations/Create
        [HttpPost]
        public ActionResult Create(Visit visit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.VisitManager.CreateVisit(visit);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return View(visit);
            }
        }

        // GET: Visitations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visitations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Visit visit)
        {
            try
            {
                visit = _manager.VisitManager.GetVisitByVisitID(id);
                if(visit == null)
                {
                    return View("Error");
                }
                else
                {
                    _manager.VisitManager.DeleteVisit(visit);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }


        [HttpPost]
        public ActionResult Reschedule(int id, Visit visit)
        {
            try
            {
                visit = _manager.VisitManager.GetVisitByVisitID(id);
                if (visit == null)
                {
                    return View("Error");
                }
                else
                {
                    _manager.VisitManager.DeleteVisit(visit);
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
