using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.Web.Domain.Models
{
    public class Manager: Person
    {
        public virtual IList<User> Users { get; set; }
        public int WorkingYearExperience { get; set; }
        
    }
}
