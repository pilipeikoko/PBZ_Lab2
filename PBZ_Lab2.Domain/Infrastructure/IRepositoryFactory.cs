using PBZ_Lab2.Domain.Repositories;

namespace PBZ_Lab2.Domain.Infrastructure
{
    public interface IRepositoryFactory
    {
        ICompanyRepository CompanyRepository { get; }
        IControlTargetRepository ControlTargetRepository { get; }
        IPollotantsRepository PollotantsRepository { get; }
        IReleaseRepository ReleaseRepository { get; }
        ISubstanceRepository SubstanceRepository { get; }
        ITechParamsRepository TechParamsRepository { get; }
    }
}