using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class Company : Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Release> Releases { get; set; }
    }
}
