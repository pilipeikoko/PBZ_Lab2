using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Domain.Repositories;
using PBZ_Lab2.Web.Data;

namespace PBZ_Lab2.Web.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected PBZ_Lab2WebContext DbContext;

        public UnitOfWork(PBZ_Lab2WebContext context)
        {
            DbContext = context;
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync(true);
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(DbContext);

        private IManagerRepository _managerRepository;
        public IManagerRepository ManagerRepository => _managerRepository ??= new ManagerRepository(DbContext);

        private IVehicleRepository _vehicleRepository;
        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(DbContext);

    }
}
