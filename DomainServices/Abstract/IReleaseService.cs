using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Models;

namespace PBZ_Lab2.DomainServices.Abstract
{
    public interface IReleaseService : ICustomService
    {
        Task<ICollection<Pollotants>> GetPollotants();
    }
}
