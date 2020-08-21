using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAA.Data.BEANS
{
    public class UniApplicationBEAN
    {
        //Thinking about the relevant attributes a university would need to see in an application via web service data
        //A visit to the .edmx allows me to gather the relevant attributes

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
        public UniApplicationBEAN() { }
    }
}