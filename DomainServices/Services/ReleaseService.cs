using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Domain.Models;
using PBZ_Lab2.DomainServices.Abstract;

namespace PBZ_Lab2.DomainServices.Services
{
    public class ReleaseService: IReleaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReleaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<ICollection<Pollotants>> GetPollotants()
        {
            throw new NotImplementedException();
        }
    }
}
