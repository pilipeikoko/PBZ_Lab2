using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class Pollotants : Entity<Guid>
    {
        private string Code { get; set; }
        private string Name { get; set; }
    }
}
