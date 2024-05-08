using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            04/20/2024
    /// Summary:            Controller for managing applications
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       04/20/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ApplicationsController : Controller
    {
        // GET: Applications
        [HttpGet]
        [AllowAnonymous]
        public ActionResult VolunteerApplication()
        {
            return View();
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            04/20/2024
        /// Summary:            Creates a volunteer application from the form.
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        // POST: Applications
        [HttpPost]
        [AllowAnonymous]
        public ActionResult VolunteerApplication(CreateVolunteerApplication application)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    MainManager mgr = MainManager.GetMainManager();

                    bool result = mgr.VolunteerApplicationManager.CreateVolunteerApplication(application);
                    if (result)
                    {
                        EmailService emailService = new EmailService();
                        emailService.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage()
                        {
                            Body = "Thank you for applying to be a volunteer! We will contact you at this email address as soon as possible to schedule an interview.",
                            Subject = "Application Received",
                            Destination = application.Email
                        });
                    }

                    return View();
                }
                else
                {
                    
                    return View(application);
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
