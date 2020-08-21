using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class UniversityController : AbstractController //Inherit Abstract controller, DRY
    {

        [HttpGet]
        // First stage of application process, select university
        public ActionResult GetUniversities(int applicant_id)
        {
            //keep track of applicant id, store in viewbag to persist
            NAA.Data.Profile tracker = _profileService.GetProfile(applicant_id);
            ViewBag.applicantid = tracker.ApplicantId;

            return View(_universityService.GetUniversities());
        }
    }
}