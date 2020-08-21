using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;

namespace NAA.Controllers
{
    public class ApplicationController : AbstractController //Inherit Abstract controller
    {


        // Stage 2: List Courses per university
        [HttpGet]
        public ActionResult ListCourses(int uni_id, int applicant_id)
        {
            //keep track of applicant id, store in viewbag to persist
            NAA.Data.Profile tracker = _profileService.GetProfile(applicant_id);
            ViewBag.applicantid = tracker.ApplicantId;

            //Trying to hack a distinct list together.
            //List<RemoteServiceModel.NAAServiceReference.Application> distinct = new List<RemoteServiceModel.NAAServiceReference.Application>();

            //foreach (RemoteServiceModel.NAAServiceReference.Application item in _courseSearchService.GetCourses(uni_id))
            //{
            //    if (!distinct.Contains(item)) distinct.Add(item);
            //}

            return View(_courseSearchService.GetCourses(uni_id));
        }

        // GET: List Applications with offers
        public ActionResult GetNotNullApplications(int applicant_id)
        {
            return View(_applicationService.GetNotNullApplications(applicant_id));
        }

        // GET: List Applications with no offers
        public ActionResult GetNullApplications(int applicant_id)
        {
            return View(_applicationService.GetNullApplications(applicant_id));
        }
    }
}