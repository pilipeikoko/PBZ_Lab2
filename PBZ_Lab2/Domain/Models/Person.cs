using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.Web.Domain.Models
{
    public class Person : Entity<Guid>
    {
        //TODO
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
