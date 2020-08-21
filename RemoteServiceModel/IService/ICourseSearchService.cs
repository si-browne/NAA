using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServiceModel.IService
{
    public interface ICourseSearchService
    {
        List<NAAServiceReference.Application> GetCourses(int uni_id);
    }
}
