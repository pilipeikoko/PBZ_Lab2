// Developed for Rhys Birthwright by Softeq Development Corporation
// http://www.softeq.com
//  

namespace PBZ_Lab2.Domain.Models
{
    public class Entity<T> : IBaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}

//DbContextOptionsBuilder optionsBuilder
//optionsBuilder
//    .UseLazyLoadingProxies()
//    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");