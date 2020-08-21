using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class ProfileDAO : IProfileDAO
    {
        private NAAEntities _context;
        public ProfileDAO()
        {
            _context = new NAAEntities();
        }

        //Unnecessary
        //public IList<Profile> GetProfiles()
        //{
        //    IQueryable<Profile> _indexes;

        //    _indexes = from index
        //                in _context.Profile
        //               select index;

        //    return _indexes.ToList();
        //}

        public Profile GetProfile(int id)
        {
            IQueryable<Profile> _profile;

            _profile = from profile
                          in _context.Profile
                            where profile.ApplicantId == id
                         select profile;

            return _profile.First();

        }

        public void EditProfile(Profile profiletoedit)
        {

            Profile profile = GetProfile(profiletoedit.ApplicantId);

            profile.ApplicantAddress = profiletoedit.ApplicantAddress;
            profile.ApplicantName = profiletoedit.ApplicantName;
            profile.Email = profiletoedit.Email;
            profile.Phone = profiletoedit.Phone;
            profile.UserId = profiletoedit.UserId;

            _context.SaveChanges();

        }

        public void AddProfile(Profile profiletoadd)
        {

            _context.Profile.Add(profiletoadd);
            _context.SaveChanges();

        }
    }
}
