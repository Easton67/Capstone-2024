using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using MvcPresentation.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;

namespace MvcPresentation.Controllers
{
    public class DonationsController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        DonationManager donationManager = new DonationManager();

        // GET: Donations
        public ActionResult Index()
        {
            List<Donation> allDonations = new List<Donation>();

            try
            {
                allDonations = _manager.DonationManager.GetDonations();
            }
            catch 
            {
                throw;
            }

            return View(allDonations);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int id)
        {
            Donation donation = new Donation();
            try
            {
                donation = _manager.DonationManager.GetDonations().FirstOrDefault(d => d.DonationID == id);
            }
            catch (Exception)
            {

                throw;
            }
            return View(donation);
        }

        private void dropdowns()
        {
            ViewBag.DonationTypes = _manager.DonationManager.GetDonationsType().Select(donation => donation.TypeName).ToList();
        }

        // GET: Donations/Create
        [Authorize]
        public ActionResult Create()
        {
            dropdowns();
            return View();
        }

        // POST: Donations/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Models.DonationVM donationvm)
        {
            try
            {
                if(donationvm.DonationName.IsNullOrWhiteSpace())
                {
                    donationvm.DonationName = "Anonymous";
                }

                DonationType donationType = _manager.DonationManager.GetDonationsType()
                                    .FirstOrDefault(d => d.TypeName == donationvm.donationType);

                if(donationType != null)
                {
                    Donation donation = new Donation()
                    {
                        DonationTypeID = donationType.DonationTypeID,
                        DonationName = donationvm.DonationName,
                        Amount = donationvm.Amount,
                        DonationDate = DateTime.Now,
                        Active = true
                    };

                    _manager.DonationManager.CreateDonation(donation);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Donation donation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     donation = (Donation)Session["oldDonation"];
                    _manager.DonationManager.UpdateDonation(donation);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(donation);
            }
        }
    }
}
