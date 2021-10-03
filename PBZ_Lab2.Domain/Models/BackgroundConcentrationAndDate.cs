using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class BackgroundConcentrationAndDate: Entity<Guid>
    {
        public float BackgroundConcentration { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
