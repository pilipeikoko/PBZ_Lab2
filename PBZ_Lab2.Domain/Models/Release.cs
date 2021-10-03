using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class Release : Entity<Guid>
    {
        public virtual TechParameters TechParameters { get; set; }
        public virtual ControlTarget ControlTarget { get; set; }

        public virtual ICollection<Pollotants> Pollotants { get; set; }
    }
}
