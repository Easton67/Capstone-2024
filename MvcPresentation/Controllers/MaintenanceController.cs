using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class MaintenanceController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        // GET: Maintenance
        public ActionResult Index()
        {
            List<MaintenanceRequest> requests = new List<MaintenanceRequest>();
            try
            {
                requests = _manager.MaintenanceRequestManager.GetMaintenanceRequests();
            }
            catch
            {
                throw;
            }
            return View(requests);
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int id)
        {
            MaintenanceRequest request = new MaintenanceRequest();

            try
            {
                request = _manager.MaintenanceRequestManager.GetMaintenanceRequests().FirstOrDefault(r => r._requestID == id);
            }
            catch
            {
                throw;
            }
            return View(request);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult Create(MaintenanceRequest request)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _manager.MaintenanceRequestManager.CreateMaintenanceRequest(request);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return View(request);
            }
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int id)
        {
            MaintenanceRequest request = new MaintenanceRequest();
            try
            {
                request = _manager.MaintenanceRequestManager.GetMaintenanceRequests().FirstOrDefault(r => r._requestID == id);
                Session["oldRequest"] = request;
            }
            catch
            {
                throw;
            }
            return View(request);
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MaintenanceRequest request)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    // MaintenanceRequest oldRequest = (MaintenanceRequest)Session["oldRequest"];
                    _manager.MaintenanceRequestManager.UpdateMaintenanceRequestStatusToCompleted(request);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(request);
            }
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int id)
        {
            MaintenanceRequest request = new MaintenanceRequest();
            try
            {
                request = _manager.MaintenanceRequestManager.GetMaintenanceRequests().FirstOrDefault(r => r._requestID == id);
            }
            catch
            {
                throw;
            }
            return View(request);
        }

        // POST: Maintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MaintenanceRequest request)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
