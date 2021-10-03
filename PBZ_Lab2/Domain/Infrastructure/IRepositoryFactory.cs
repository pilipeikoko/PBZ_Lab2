using PBZ_Lab2.Domain.Repositories;

namespace PBZ_Lab2.Domain.Infrastructure
{
    public interface IRepositoryFactory
    {
        IUserRepository UserRepository { get; }
        IVehicleRepository VehicleRepository{ get; }
        IManagerRepository ManagerRepository { get; }
    }
}