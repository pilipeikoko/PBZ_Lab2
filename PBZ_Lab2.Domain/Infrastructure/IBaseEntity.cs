

namespace PBZ_Lab2.Domain.Infrastructure
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}