using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class Substance : Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual SubstanceGroup SubstanceGroup { get; set; }
        public DangerClass DangerClass { get; set; }
    }
}
