using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAARemSerMod.Services.IService
{
    interface ICourseService
    {
        IList<uk.ac.shu.hallam.webteach_net.Application> GetCourses(string course);
    }
}
