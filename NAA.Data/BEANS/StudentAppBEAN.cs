using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class StudentAppBEAN
    {
        //Thinking about the relevant attributes a university would need to see in a STUDENT application via web service data
        //This requires just another parameter (UniversityId, ApplicationId)

        //ApplicationId
        //CourseName
        //PersonalStatement
        //UniversityOffer
        //Firm

        //ApplicantId
        //ApplicantName
        //ApplicantAddress
        //Phone
        //Email

        public int UniversityId { get; set; }
        public int ApplicationId { get; set; }
        public string CourseName { get; set; }
        public string PersonalStatement { get; set; }
        public string UniversityOffer { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Firm { get; set; }
        public StudentAppBEAN() { }
    }
}
