using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class ErrorPagesController : Controller
    {
        // GET: ErrorPage
        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}