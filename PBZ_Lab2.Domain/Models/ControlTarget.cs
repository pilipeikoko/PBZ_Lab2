using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class ControlTarget : Entity<Guid>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
    }
}
