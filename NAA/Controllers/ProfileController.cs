using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class ProfileController : AbstractController
    {

        //[Authorize(Roles = "Admin,Staff,Applicant,User")]
        // GET: Profile/GetProfile/#
        public ActionResult GetProfile(int id)
        {
            ViewBag.profileid = id;
            return View(_profileService.GetProfile(id));
        }
    }
}
