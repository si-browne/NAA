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
    public class ProfileService : NAA.Services.IService.IProfileService
    {
        private IProfileDAO _ProfileDAO;

        public ProfileService()
        {
            _ProfileDAO = new ProfileDAO();
        }

        public Profile GetProfile(int id) {

            return _ProfileDAO.GetProfile(id);
        }

        public void EditProfile(Profile profiletoedit) {

            _ProfileDAO.EditProfile(profiletoedit);

        }

        public void AddProfile(Profile profiletoadd) {

            _ProfileDAO.AddProfile(profiletoadd);

        }

    }
}
