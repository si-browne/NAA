using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    //abstract controller class, contains abstract methods
    //abstract Animal class can be (dog, cat, pig) 
    //can have abstract methods for noise(), sleep(), eat(), ubiquitous
    //abstract classes are sometimes used over interfaces, as interface cannot provide method implementations
    public abstract class AbstractController : Controller //DRY - Dont Repeat yourself
    {
        public RemoteServiceModel.IService.ICourseSearchService _courseSearchService;
        public NAA.Services.IService.IApplicationService _applicationService;
        public NAA.Services.IService.IUniversityService _universityService;
        public NAA.Services.IService.IProfileService _profileService;
        
        public AbstractController()
        {
            _courseSearchService = new RemoteServiceModel.Service.CourseSearchService();
            _applicationService = new NAA.Services.Service.ApplicationService();
            _universityService = new NAA.Services.Service.UniversityService();
            _profileService = new NAA.Services.Service.ProfileService();
        }
        

    }
}