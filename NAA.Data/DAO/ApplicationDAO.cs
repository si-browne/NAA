using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.BEANS;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        private NAAEntities _context;
        public ApplicationDAO()
        {
            _context = new NAAEntities();
        }

        public IList<Application> GetApplications()
        {
            IQueryable<Application> _applications;

            _applications = from index
                            in _context.Application
                            select index;

            return _applications.ToList();
        }

        public IList<Application> GetUniApplications(int uni_id)
        {
            IQueryable<Application> _applications;

            _applications = from index
                            in _context.Application
                            where index.UniversityId == uni_id
                            select index;

            return _applications.ToList();
        }

        public IList<Application> GetNullApplications(int applicant_id)
        {
            IQueryable<Application> _applications;

            _applications = from index
                            in _context.Application
                            where index.ApplicantId == applicant_id && index.UniversityOffer == null
                            select index;

            return _applications.ToList();
        }

        public IList<Application> GetNotNullApplications(int applicant_id)
        {
            IQueryable<Application> _applications;

            _applications = from index
                            in _context.Application
                            where index.ApplicantId == applicant_id && index.UniversityOffer != null 
                            select index;

            return _applications.ToList();
        }

        public Application GetApplication(int id)
        {
            IQueryable<Application> _application;

            _application = from application
                          in _context.Application
                       where application.ApplicationId == id
                       select application;

            return _application.First();
        }

        public Application GetCourse(int uni_id, string course)
        {
            IQueryable<Application> _application;

            _application = from findcourse
                           in _context.Application
                           where findcourse.UniversityId == uni_id && findcourse.CourseName == course
                           select findcourse;

            return _application.First();
        }

        public Application GetStudentApplication(int application_id, int uni_id)
        {
            IQueryable<Application> _application;

            _application =  from    findapplicant
                            in      _context.Application
                            where   findapplicant.ApplicationId == application_id && findapplicant.UniversityId == uni_id
                            select  findapplicant;

            return _application.First();
        }

        //Scope of offer is nvarchar(10), use param to identify first letter
        //First letter would be:
        //N = Not Processed
        //C = Conditional offer 
        //U = Unconditional offer
        //R = Rejected
        //P = Pending
        //F = Firm
        //Grabbing first char of offer using substring.
        public Application GetStudentApplicationToOffer(int application_id, int uni_id, string offer)
        {
            IQueryable<Application> _application;

            _application = from findapplicant
                           in _context.Application
                           where findapplicant.ApplicationId == application_id
                           && findapplicant.UniversityId == uni_id
                           //&& findapplicant.UniversityOffer.Substring(0,1).Contains(offer) - annoying wouldent work
                           && findapplicant.UniversityOffer.Substring(0, 1) == offer
                           select findapplicant;

            return _application.First();
        }

        public void UpdateApplication(Application AppToUp)
        {

            Application application = GetStudentApplication(AppToUp.ApplicationId, AppToUp.UniversityId);

            application.UniversityOffer = AppToUp.UniversityOffer;

            _context.SaveChanges();

        }

        public void CreateApplication(Application createApp)
        {
            _context.Application.Add(createApp);
            _context.SaveChanges();
        }

        public Application GetCourse(string coursename)
        {
            IQueryable<Application> _course;

            _course = from findcourse
                      in _context.Application
                      where findcourse.CourseName == coursename
                      select findcourse;

            return _course.First();

        }

        public void DeleteApplication(Application appDelete)
        {

            _context.Application.Remove(appDelete);
            _context.SaveChanges();

        }

        
        //1. Set all applications to false, first, per applicant that wishes to.
        public void setFirmFalse(int applicant_id, IList<Application> postList)
        {
                IQueryable<Application> _applications;

                //grab true applications per applicant id
                _applications = from index
                                in _context.Application
                                where index.Firm == true && index.ApplicantId == applicant_id
                                select index;

            postList = _applications.ToList();

            //set each true item in postList false
            foreach (Application item in postList)
            {
                item.Firm = false;
            }

            //save changes
            _context.SaveChanges();
        }

        public void setFirmTrue(Application AppToUp)
        {

            Application application = GetApplication(AppToUp.ApplicationId);

            application.Firm = true;

            _context.SaveChanges();

        }

        public IList<UniApplicationBEAN> GetUniApplicationsBEAN(int UniversityId) {

            IQueryable<UniApplicationBEAN> _uniappBEANs = from apps in _context.Application
                                                          from prof in _context.Profile
                                                          where apps.ApplicantId == prof.ApplicantId
                                                          where apps.UniversityId == UniversityId
                                                          select new UniApplicationBEAN
                                                          {
                                                              UniversityId = apps.UniversityId,
                                                              ApplicationId = apps.ApplicationId,
                                                              CourseName = apps.CourseName,
                                                              PersonalStatement = apps.PersonalStatement,
                                                              UniversityOffer = apps.PersonalStatement,
                                                              Firm = apps.Firm,
                                                              ApplicantId = prof.ApplicantId,
                                                              ApplicantName = prof.ApplicantName,
                                                              ApplicantAddress = prof.ApplicantAddress,
                                                              Phone = prof.Phone,
                                                              Email = prof.Email


                                                          };

            return _uniappBEANs.ToList<UniApplicationBEAN>();
        }

        public IList<StudentAppBEAN> GetStudentAppsBEAN(int UniversityId, int ApplicationId) {

            IQueryable<StudentAppBEAN> _studentAppsBEAN = from apps in _context.Application
                                                          from prof in _context.Profile
                                                          where apps.ApplicantId == prof.ApplicantId
                                                          where apps.ApplicationId == ApplicationId
                                                          where apps.UniversityId == UniversityId
                                                          select new StudentAppBEAN
                                                          {
                                                              UniversityId = apps.UniversityId,
                                                              ApplicationId = apps.ApplicationId,
                                                              CourseName = apps.CourseName,
                                                              PersonalStatement = apps.PersonalStatement,
                                                              UniversityOffer = apps.PersonalStatement,
                                                              Firm = apps.Firm,
                                                              ApplicantId = prof.ApplicantId,
                                                              ApplicantName = prof.ApplicantName,
                                                              ApplicantAddress = prof.ApplicantAddress,
                                                              Phone = prof.Phone,
                                                              Email = prof.Email


                                                          };

            return _studentAppsBEAN.ToList<StudentAppBEAN>();
        }
    }
}
