using InvestorsApp.Core;

namespace InvestorsApp.Infrastructure.RepositoryInterfaces
{
    public interface ICompanyRepository
    {
        Task<List<CompanyDto>> GetCompanies();

        Task<CompanyDto?> GetCompany(string code);

        Task<CompanyDto?> AddCompany(CompanyAddDto company);
    }
}
