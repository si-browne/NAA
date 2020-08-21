using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.IDAO;
using NAA.Data.DAO;
using NAA.Data.BEANS;

namespace NAA.Services.Service
{
    public class ApplicationService : NAA.Services.IService.IApplicationService
    {
        private IApplicationDAO _ApplicationDAO;

        public ApplicationService()
        {
            _ApplicationDAO = new ApplicationDAO();
        }

        public IList<Application> GetApplications()
        {
            return _ApplicationDAO.GetApplications();
        }

        public IList<Application> GetNullApplications(int applicant_id)
        {
            return _ApplicationDAO.GetNullApplications(applicant_id);
        }

        public IList<Application> GetNotNullApplications(int applicant_id)
        {
            return _ApplicationDAO.GetNotNullApplications(applicant_id);
        }

        public Application GetCourse(int uni_id, string course)
        {
            return _ApplicationDAO.GetCourse(uni_id, course);
        }

        public IList<Application> GetUniApplications(int uni_id)
        {
            return _ApplicationDAO.GetUniApplications(uni_id);
        }
        public Application GetApplication(int id)
        {
            return _ApplicationDAO.GetApplication(id);
        }

        public void CreateApplication(Application createApp)
        {
            _ApplicationDAO.CreateApplication(createApp);
        }

        public void UpdateApplication(Application AppToUp)
        {
            _ApplicationDAO.UpdateApplication(AppToUp);
        }

        public Application GetStudentApplication(int application_id, int uni_id)
        {
            return _ApplicationDAO.GetStudentApplication(application_id, uni_id);
        }

        public Application GetStudentApplicationToOffer(int application_id, int uni_id, string offer)
        {
            return _ApplicationDAO.GetStudentApplicationToOffer(application_id, uni_id, offer);
        }

        public Application GetCourse(string coursename)
        {
            return _ApplicationDAO.GetCourse(coursename);
        }

        public void DeleteApplication(Application appDelete)
        {
            _ApplicationDAO.DeleteApplication(appDelete);
        }

        public void setFirmFalse(int applicant_id, IList<Application> postList)
        {
            _ApplicationDAO.setFirmFalse(applicant_id, postList);
        }

        public void setFirmTrue(Application AppToUp) {

            _ApplicationDAO.setFirmTrue(AppToUp);
        }

        public IList<UniApplicationBEAN> GetUniApplicationsBEAN(int UniversityId) {

            return _ApplicationDAO.GetUniApplicationsBEAN(UniversityId);
        }

        public IList<StudentAppBEAN> GetStudentAppsBEAN(int UniversityId, int ApplicationId) {

            return _ApplicationDAO.GetStudentAppsBEAN(UniversityId, ApplicationId);
        }

    }
}
