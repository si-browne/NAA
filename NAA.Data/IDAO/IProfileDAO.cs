using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IProfileDAO
    {

        Profile GetProfile(int id);

        void EditProfile(Profile profiletoedit);

        void AddProfile(Profile profiletoadd);
    }
}
