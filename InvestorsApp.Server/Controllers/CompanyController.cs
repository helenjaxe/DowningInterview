using InvestorsApp.Core;
using InvestorsApp.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestorsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyRepository companyRepo) : ControllerBase
    {
        /// <summary>
        /// Get an individual company by company code
        /// </summary>
        [HttpGet("{code}")]
        public async Task<ActionResult<CompanyDto>> Get([FromRoute] string code)
        {
            var result = await companyRepo.GetCompany(code);
            return Ok(result);
        }

        /// <summary>
        /// Get all companies
        /// </summary>
        [HttpGet()]
        public async Task<ActionResult<List<CompanyDto>>> Get()
        {
            var result = await companyRepo.GetCompanies();
            return Ok(result);
        }

        /// <summary>
        /// Create company
        /// </summary>
        [HttpPost()]
        public async Task<ActionResult<CompanyDto>> Create(CompanyAddDto company)
        {
            await companyRepo.AddCompany(company);
            var result = await companyRepo.GetCompany(company.Code);

            return Ok(result);
        }
    }
}
