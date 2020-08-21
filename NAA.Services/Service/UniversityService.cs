using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.IDAO;
using NAA.Data.DAO;

namespace NAA.Services.Service
{
    public class UniversityService : NAA.Services.IService.IUniversityService
    {
        private IUniversityDAO _UniversityDAO;

        public UniversityService()
        {
            _UniversityDAO = new UniversityDAO();
        }

        public IList<University> GetUniversities()
        {
            return _UniversityDAO.GetUniversities();
        }
    }
}
