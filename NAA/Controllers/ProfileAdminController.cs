using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class ProfileAdminController : AbstractController
    {

        // GET: ProfileAdmin/AddProfile/#
        public ActionResult AddProfile()
        {
            return View();
        }

        // POST: ProfileAdmin/AddProfile/#
        [HttpPost]
        public ActionResult AddProfile(Profile profile)
        {
            try
            {
                // Add Profile logic
                _profileService.AddProfile(profile);

                return RedirectToAction("GetProfile", "Profile", 7);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileAdmin/EditProfile/#
        public ActionResult EditProfile(int id)
        {

            return View(_profileService.GetProfile(id));
        }

        // POST: ProfileAdmin/EditProfile/#
        [HttpPost]
        public ActionResult EditProfile(int id, Profile recording)
        {
            try
            {
                // Edit Profile logic
                _profileService.EditProfile(recording);

                return RedirectToAction("GetProfile", "Profile", id);
            }
            catch
            {
                return View();
            }
        }
    }
}
