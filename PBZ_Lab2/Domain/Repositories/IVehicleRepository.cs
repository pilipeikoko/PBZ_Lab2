using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Domain.Models;
using PBZ_Lab2.Web.Domain.Models;

namespace PBZ_Lab2.Domain.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle, Guid>

    {
    }
}
