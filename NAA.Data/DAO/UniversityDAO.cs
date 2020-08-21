using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class UniversityDAO : IUniversityDAO
    {
        private NAAEntities _context;
        public UniversityDAO()
        {
            _context = new NAAEntities();
        }

        public IList<University> GetUniversities()
        {
            IQueryable<University> _indexes;

            _indexes = from index
                        in _context.University
                       select index;

            return _indexes.ToList();
        }
    }
}
