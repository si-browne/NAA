using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using Microsoft.AspNet.Identity;
using NAA.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NAA.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController() {

            _context = new NAA.Models.ApplicationDbContext();
        }
        public ActionResult AdminHome()
        {

            return View();
        }
        public ActionResult GetUsers() {

            return View(_context.Users.ToList());
        }

        public ActionResult GetRoles() {

            return View(_context.Roles.ToList());
        }

        [HttpGet]
        public ActionResult AddRole() {

            return View();
        }

        [HttpPost]
        public ActionResult AddRole(FormCollection collection) {

            try
            {
                IdentityRole role = new IdentityRole();

                role.Name = collection["RoleName"];

                _context.Roles.Add(role);

                _context.SaveChanges();

                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        //Prepare lists for usernames and for the roles
        [HttpGet]
        public ActionResult ManageUserRoles() {

            //populate roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            ViewBag.Roles = roleList;

            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();

            ViewBag.Users = userList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName) {

            ApplicationUser user =
                _context.Users.Where
                (u => u.UserName.Equals(UserName,
                    StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);
            // prepopulate roles for the view dropdown
            var roleList = _context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            // prepopulate users for the view dropdown
            var userList = _context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();

            ViewBag.Users = userList;

            return View("ManageUserRoles");

        }

        [HttpGet]
        public ActionResult GetRolesforUser() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRolesforUser(string UserName) {

            if (!string.IsNullOrWhiteSpace(UserName))
            { 
                ApplicationUser user =
                    _context.Users.Where(u => u.UserName.Equals
                        (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesforUserConfirmed");
        }

        

    }
}