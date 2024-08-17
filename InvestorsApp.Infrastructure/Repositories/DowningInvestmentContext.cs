using InvestorsApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestorsApp.Infrastructure.Repositories
{
    public class DowningInvestmentContext : DbContext
    {
        public DowningInvestmentContext(DbContextOptions<DowningInvestmentContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().ToTable("Companies")
                .HasKey("Id");

           modelBuilder.Entity<Company>().Property(i => i.SharePrice).HasColumnType("money");     
        }
    }
}
