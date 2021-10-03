using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;


namespace PBZ_Lab2.Web.Domain.Models
{
    public class Vehicle : Entity<Guid>
    {
        public string RegistrationNumber { get; set; }
        public virtual Location Location { get; set; }
    }
}
