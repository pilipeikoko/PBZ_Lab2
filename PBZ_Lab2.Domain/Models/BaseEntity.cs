// Developed for Rhys Birthwright by Softeq Development Corporation
// http://www.softeq.com
//  
using System.ComponentModel.DataAnnotations;
using PBZ_Lab2.Domain.Infrastructure;

namespace PBZ_Lab2.Domain.Models
{
    public class Entity<T> : IBaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}