using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.IService
{
    public interface IProfileService
    {

        Profile GetProfile(int id);

        void EditProfile(Profile profiletoedit);

        void AddProfile(Profile profiletoadd);
    }
}
