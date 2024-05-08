using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class TransportationController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();

        // GET: Transportation
        public ActionResult Index(string searchText)
        {
            List<TransportationOrderVM> orders = new List<TransportationOrderVM>();

            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    orders = _manager.TransportationOrderManager.ViewAllTransportationOrders()
                                                                .Where(x => x.TransportItem.ToLower().Contains(searchText))
                                                                .ToList();
                }
                else
                {
                    orders = _manager.TransportationOrderManager.ViewAllTransportationOrders();
                } 
            }
            catch (Exception)
            {
                throw;
            }
           
            return View(orders);
        }

        // GET: Transportation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transportation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportation/Create
        [HttpPost]
        public ActionResult Create(TransportationOrder order)
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

        // GET: Transportation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transportation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TransportationOrder order)
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

        // GET: Transportation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transportation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TransportationOrder order)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
