using FluentAssertions;
using InvestorsApp.Core;
using InvestorsApp.Infrastructure.Data;
using InvestorsApp.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace InvestorsApp.Server.Test.Repositories
{
    [TestClass]
    public class CompanyRepositoryTests
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<DowningInvestmentContext> _contextOptions;

        public CompanyRepositoryTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<DowningInvestmentContext>()
                .UseSqlite(_connection)
                .Options;

            using (var context = new DowningInvestmentContext(_contextOptions))
                context.Database.EnsureCreated();
        }

        DowningInvestmentContext CreateContext() => new DowningInvestmentContext(_contextOptions);

        public void Dispose() => _connection.Dispose();

        #region GetCompany

        [TestMethod]
        public async Task GetCompany_ReturnsCompanyByCode()
        {
            var code = "ABC";
            var companyName = "Company1";

            using var context = CreateContext();

            var companyList = new List<Company>()
            {
                new Company()
                {
                   Id = 1,
                   CompanyName = companyName,
                   Code = code,
                   SharePrice = 23.23M,
                   CreatedDate = DateTime.Now
                },
                new Company()
                {
                   Id = 2,
                   CompanyName = "Company 2",
                   Code = "XYZ",
                   SharePrice = 63.23M,
                   CreatedDate = DateTime.Now
                }
            };

            context.AddRange(companyList);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            CompanyRepository repo = new CompanyRepository(context);

            var company = await repo.GetCompany(code);

            company!.CompanyName.Should().Be(companyName);

        }

        [TestMethod]
        public async Task GetCompany_ReturnsNullIfCodeUnknown()
        {
            using var context = CreateContext();

            var companyList = new List<Company>()
            {
                new Company()
                {
                   Id = 1,
                   CompanyName = "Name",
                   Code = "ABC",
                   SharePrice = 23.23M,
                   CreatedDate = DateTime.Now
                }
            };

            context.AddRange(companyList);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            CompanyRepository repo = new CompanyRepository(context);

            var company = await repo.GetCompany("MGS");
            company.Should().BeNull();
        }

        [TestMethod]
        public async Task GetCompany_ErrorsIfCodeBlank()
        {
            using var context = CreateContext();

            var companyList = new List<Company>()
            {
                new Company()
                {
                   Id = 1,
                   CompanyName = "Name",
                   Code = "ABC",
                   SharePrice = 23.23M,
                   CreatedDate = DateTime.Now
                }
            };

            context.AddRange(companyList);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            CompanyRepository repo = new CompanyRepository(context);

            Func<Task> act = async () => { await repo.GetCompany(""); };
            await act.Should().ThrowAsync<Exception>();
        }

        #endregion GetCompany

        #region GetCompanies

            [TestMethod]
        public async Task GetCompanies_SortsByName()
        {
            var companyName1 = "A Company";
            var companyName2 = "B Company";
            var companyName3 = "C Company";

            using var context = CreateContext();

            var companyList = new List<Company>()
            {
                new Company()
                {
                   Id = 1,
                   CompanyName = companyName2,
                   Code = "ABC",
                   SharePrice = 23.23M,
                   CreatedDate = DateTime.Now
                },
                new Company()
                {
                   Id = 2,
                   CompanyName = companyName1,
                   Code = "XYZ",
                   SharePrice = 69.23M,
                   CreatedDate = DateTime.Now
                },
                new Company()
                {
                   Id = 3,
                   CompanyName = companyName3,
                   Code = "LMN",
                   SharePrice = 63.23M,
                   CreatedDate = DateTime.Now
                }
            };

            context.AddRange(companyList);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            CompanyRepository repo = new CompanyRepository(context);

            var companies = await repo.GetCompanies();

            companies[0].CompanyName.Should().Be(companyName1);
            companies[1].CompanyName.Should().Be(companyName2);
            companies[2].CompanyName.Should().Be(companyName3);
        }

        #endregion GetCompanies

        #region AddCompany

        [TestMethod]
        public async Task AddCompany_DoesntAddIfCodeExists()
        {
            var code = "KLM";

            using var context = CreateContext();

            var companyList = new List<Company>()
            {
                new Company()
                {
                   Id = 1,
                   CompanyName = "Name",
                   Code = code,
                   SharePrice = 23.23M,
                   CreatedDate = DateTime.Now
                }
            };

            var newCompany = new CompanyAddDto { Code = code, CompanyName = "New" };

            context.AddRange(companyList);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            CompanyRepository repo = new CompanyRepository(context);

            Func<Task> act = async () => { await repo.AddCompany(newCompany); };
            await act.Should().ThrowAsync<Exception>();
        }

        [TestMethod]
        public async Task AddCompany_AddsCompany()
        {
            using var context = CreateContext();

            var newCompany = new CompanyAddDto { Code = "ABC", CompanyName = "Name" };

            CompanyRepository repo = new CompanyRepository(context);

            await repo.AddCompany(newCompany);
            context.Companies.Count().Should().Be(1);
        }

        [TestMethod]
        public async Task AddCompany_PopulatesCreatedDate()
        {
            using var context = CreateContext();

            var newCompany = new CompanyAddDto { Code = "ABC", CompanyName = "Name" };

            CompanyRepository repo = new CompanyRepository(context);

            await repo.AddCompany(newCompany);
            var company = await context.Companies.FirstOrDefaultAsync();

            company!.CreatedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
        }

        #endregion AddCompany
    }
}
