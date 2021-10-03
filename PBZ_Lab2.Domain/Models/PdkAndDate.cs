using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class PdkAndDate : Entity<Guid>
    {
        public float Pdk { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
