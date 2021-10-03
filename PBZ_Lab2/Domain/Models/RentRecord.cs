using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.Web.Domain.Models
{
    public class RentRecord : Entity<Guid>
    {
        public virtual IList<Location> Locations { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
