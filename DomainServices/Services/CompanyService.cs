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
    class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ICollection<Release>> GetAllReleasesOnDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
