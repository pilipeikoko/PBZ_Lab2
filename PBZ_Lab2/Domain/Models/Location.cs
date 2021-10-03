using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.Web.Domain.Models
{
    public class Location : Entity<Guid>
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
