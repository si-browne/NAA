using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA.Services.IService
{
    public interface IApplicationService
    {
        IList<Application> GetApplications();

        IList<Application> GetUniApplications(int uni_id);

        IList<Application> GetNullApplications(int applicant_id);

        IList<Application> GetNotNullApplications(int applicant_id);

        Application GetCourse(int uni_id, string course);

        Application GetApplication(int id);

        Application GetStudentApplication(int application_id, int uni_id);

        Application GetStudentApplicationToOffer(int application_id, int uni_id, string offer);

        void CreateApplication(Application createApp);

        void UpdateApplication(Application AppToUp);

        Application GetCourse(string coursename);

        void DeleteApplication(Application appDelete);

        void setFirmFalse(int applicant_id, IList<Application> postList);

        void setFirmTrue(Application AppToUp);

        IList<UniApplicationBEAN> GetUniApplicationsBEAN(int UniversityId);

        IList<StudentAppBEAN> GetStudentAppsBEAN(int UniversityId, int ApplicationId);

    }
}
