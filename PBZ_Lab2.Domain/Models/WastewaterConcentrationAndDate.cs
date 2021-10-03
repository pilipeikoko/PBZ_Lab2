using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class WastewaterConcentrationAndDate: Entity<Guid>
    {
        public float WastewaterConcentration { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
