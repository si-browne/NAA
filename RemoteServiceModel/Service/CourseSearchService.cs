using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServiceModel.Service
{
    public class CourseSearchService : IService.ICourseSearchService
    {
        private NAAServiceReference.NAAWebService _proxy;

        public CourseSearchService()
        {
            _proxy = new NAAServiceReference.NAAWebService();
            //add auth to constructor of class
            //Ask mo about this
            _authenticationHeader = new NAAServiceReference.AuthenticationHeader();
        }

        //Successfully able to list courses & course details via web service
        //Successfully integrated proxy class.
        public List<NAAServiceReference.Application> GetCourses(int uni_id)
        {
            _authenticationHeader.User = "johnny";
            _authenticationHeader.Pass = "bgood";
            return _proxy.GetUniApplications(uni_id).ToList();
        }

        //Applicant should pick university first then course
        //This app needs to get course info through consuming web service

        private NAAServiceReference.AuthenticationHeader _authenticationHeader;


        //This doesnt work, instead place _auth into constructor.
        //Ask mo
        //public NAAServiceReference() {
        //    _authenticationHeader = new NAAServiceReference.AuthenticationHeader();
        //}


        public IList<NAAServiceReference.Application> GetApplications(int uni_id)
        {
            _authenticationHeader.User = "johnny";
            _authenticationHeader.Pass = "bgood";
            _proxy.AuthenticationHeaderValue = _authenticationHeader;

            return _proxy.GetUniApplications(uni_id).ToList();
        }

    }
}
