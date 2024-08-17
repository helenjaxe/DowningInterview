namespace InvestorsApp.Core
{
    public class CompanyAddDto
    {
        public required string CompanyName { get; set; }
        public required string Code { get; set; }
        public decimal? SharePrice { get; set; }
    }
}
