using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.Domain.Repositories
{
    public interface IReleaseRepository : IRepository<Release, Guid>

    {
    }
}
