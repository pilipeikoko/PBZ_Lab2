﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Repositories;
using PBZ_Lab2.SQLRepository.Repositories;
using PBZ_Lab2.Web.Data;
using PBZ_Lab2.Web.Domain.Models;

namespace PBZ_Lab2.Web.Repository.Repositories
{
    public class VehicleRepository : RepositoryBase<Vehicle,Guid>,IVehicleRepository
    {
        public VehicleRepository(PBZ_Lab2WebContext context) : base(context)
        {
        }
    }
}
