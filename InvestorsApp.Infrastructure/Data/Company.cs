using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace InvestorsApp.Infrastructure.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Code { get; set; }
        public decimal? SharePrice { get; set; }
    }
}
