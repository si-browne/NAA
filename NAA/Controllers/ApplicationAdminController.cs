using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;

namespace NAA.Controllers
{
    public class ApplicationAdminController : AbstractController //Inherit Abstract controller
    {
        //Added RemoteServiceModel to references.
        [HttpGet]
        // GET: ApplicationAdmin/MakeApplication/+1
        public ActionResult MakeApplication(int uni_id, int applicant_id, string course)
        {

            Profile trackPro = _profileService.GetProfile(applicant_id);
            ViewBag.applicantid = trackPro.ApplicantId;

            Application trackApp = _applicationService.GetCourse(uni_id, course);
            ViewBag.uni_id = uni_id;
            ViewBag.applicant_id = applicant_id;
            ViewBag.teacher_ref = trackApp.TeacherReference;
            ViewBag.teacher_con = trackApp.TeacherContactDetails;
            ViewBag.course = trackApp.CourseName;

            //grab bottom row, add one for new ID.
            IList<Application> newrow = _applicationService.GetApplications();
            ViewBag.newrow = newrow.Last().ApplicationId;
            ViewBag.newrow = ViewBag.newrow + 1;



            return View();
        }

        // POST: ApplicationAdmin/MakeApplication/+1
        //TESTED AND WORKING.
        [HttpPost]
        public ActionResult MakeApplication(Application newApp)
        {
            //Regex regExp = new Regex("^[\\p{L} .'-]+$");

            //example of validation on post when making application
            if (String.IsNullOrEmpty(newApp.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Please enter a personal statement. Cancel your application and start again");
            }
            ////implement regex check, not working
            //else if (!regExp.IsMatch(newApp.PersonalStatement))
            //{
            //    ModelState.AddModelError("PersonalStatement", "Please use plain text characters only.");
            //}
            else if (newApp.PersonalStatement.Length < 2)
            {
                ModelState.AddModelError("PersonalStatement", "Please enter more than 2 characters. Cancel your application and start again.");
            }
            else if (newApp.PersonalStatement.Length > 200)
            {
                ModelState.AddModelError("PersonalStatement", "Personal statement too long, please use less than 200 characters. Cancel your application and start again.");
            }

            if (ModelState.IsValid)
            {
                // Add new application
                _applicationService.CreateApplication(newApp);

                return RedirectToAction("GetProfile", "Profile", 7);
            }else
            {
                //not sure how to return the correct view here.
                return View();
            }
            
        }

        [HttpGet]
        // GET: ApplicationAdmin/Delete/#
        public ActionResult DeleteApplication(int id)
        {
            return View(_applicationService.GetApplication(id));
        }

        // POST: ApplicationAdmin/Delete/#
        [HttpPost]
        public ActionResult DeleteApplication(int id, Application apptoDelete)
        {
 
            //Delete logic
            Application _application;

            //check for pre offer here
            _application = _applicationService.GetApplication(id);

            //check to see if application is not firm
            //if true, let application delete it
            //tried to implement sorting of firm offers via 2 views.
            //GetNullApplications
            //GetNotNullApplications
            if (_application.UniversityOffer != "Firm")
            {
                _applicationService.DeleteApplication(_application);
                return RedirectToAction("GetProfile", "Profile", 7);
            }

            else
            {
                return RedirectToAction("GetProfile", "Profile", 7);
            }
        }


        //Silent void method, clean the slate, prep for unique firm assignment to application.
        // GET: ApplicationAdmin/setFirmFalse/#
        [HttpGet]
        public ActionResult setFirmFalse(int application_id, int applicant_id)
        {
            IList<Application> notNullList = _applicationService.GetNotNullApplications(applicant_id);

            _applicationService.setFirmFalse(applicant_id, notNullList);

            return View(_applicationService.GetApplication(application_id));
        }

        [HttpGet]
        public ActionResult setFirmTrue(int application_id)
        {
            //works, validation filtering rejected status applications
            if (_applicationService.GetApplication(application_id).UniversityOffer != "Rejected")
            {
                return View(_applicationService.GetApplication(application_id));
            }
            else
            {
                //return user back to profile without allowing firm status on rejected application.
                return RedirectToAction("GetProfile", "Profile", 7);

                //TempData["Message"] = "firm status on rejected application Error";
                //@TempData["Message"]
            }

        }
        // POST: ApplicationAdmin/setFirmTrue/#
        [HttpPost]
        public ActionResult setFirmTrue(int application_id, Application appToUp)
        {
            try
            {
                // update firm to true logic

                     _applicationService.setFirmTrue(appToUp);
                return RedirectToAction("GetProfile", "Profile", appToUp.ApplicantId);
            }
            catch
            {
                return RedirectToAction("GetProfile", "Profile", appToUp.ApplicantId);
            }
        }

    }
}