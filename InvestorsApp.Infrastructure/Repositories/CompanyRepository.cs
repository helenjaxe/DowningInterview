using InvestorsApp.Core;
using InvestorsApp.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InvestorsApp.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DowningInvestmentContext _context;

        public CompanyRepository(DowningInvestmentContext context)
        {
            _context = context; 
        }

        public async Task<List<CompanyDto>> GetCompanies()
        {
            return await _context.Companies
                .OrderBy(c => c.CompanyName)
                .Select(c => new CompanyDto { Code = c.Code, CompanyName = c.CompanyName, CreatedDate = c.CreatedDate, SharePrice = c.SharePrice })
                .ToListAsync();
        }

        public async Task<CompanyDto?> GetCompany(string code)
        {
            if(string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("GetCompany failed. Code not provided");
            }

            return await _context.Companies
                .Where(c => c.Code == code)
                .Select(c => new CompanyDto { Code = c.Code, CompanyName = c.CompanyName, CreatedDate = c.CreatedDate, SharePrice = c.SharePrice })
                .SingleOrDefaultAsync();
        }

        public async Task<CompanyDto?> AddCompany(CompanyAddDto company)
        {
            var existingCompany = GetCompany(company.Code);

            if (existingCompany != null)
            {
                await _context.Companies.AddAsync(new Data.Company { Code = company.Code, CompanyName = company.CompanyName, SharePrice = company.SharePrice, CreatedDate = DateTime.Now });
                await _context.SaveChangesAsync();

                return await GetCompany(company.Code);
            }
            else
            {
                throw new Exception("AddCompany failed. Code already exists");
            }
        }
    }
}
