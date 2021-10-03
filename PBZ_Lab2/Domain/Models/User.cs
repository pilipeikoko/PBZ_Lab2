using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBZ_Lab2.Web.Domain.Models
{
    public class User : Person
    {
        public string PassportPhoto { get; set; }
        public string DrivingLicensePhoto { get; set; }
        public virtual Location Location { get; set; }
        public int DrivingYearExperience { get; set; }
        public bool isBlocker { get; set; }
        public virtual IList<RentRecord> RentRecords { get; set; }
        public float Rating { get; set; }
    }
}
