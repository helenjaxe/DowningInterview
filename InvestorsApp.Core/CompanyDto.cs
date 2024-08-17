namespace InvestorsApp.Core
{
    public class CompanyDto
    {
        public string? CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Code { get; set; }
        public decimal? SharePrice { get; set; }
    }
}
