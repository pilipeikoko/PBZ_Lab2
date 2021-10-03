using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Infrastructure
{
    public interface IUnitOfWork : IRepositoryFactory
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}