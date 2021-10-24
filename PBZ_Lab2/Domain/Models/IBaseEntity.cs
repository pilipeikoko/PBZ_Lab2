namespace PBZ_Lab2.Domain.Models
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}