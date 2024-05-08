using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MvcPresentation.Models;

namespace MvcPresentation.Controllers
{
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: Admin
        public ActionResult Index(string searchText)
        {
            var users = new List<ApplicationUser>();

            try
            {
                _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                if (!string.IsNullOrEmpty(searchText))
                {
                    users = _userManager.Users.Where(n => n.Email.Contains(searchText)).ToList();
                }
                else
                {
                    users = _userManager.Users.OrderBy(n => n.Email).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return View(users);
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // ApplicationUser applicationUser = db.ApplicationUsers.Find(id)
            _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser applicationUser = _userManager.FindById(id);

            if(applicationUser == null)
            {
                return HttpNotFound();
            }

            // get a list of roles the user has and put them into a viewbag as roles 
            // along with a list of the roles the user doesn't have as noRoles
            var usrMgr = new LogicLayer.UserManager();
            var allRoles = usrMgr.SelectAllRoles().Select(x => x.RoleID);

            var roles = _userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            return View(applicationUser);
        }
    }
}
