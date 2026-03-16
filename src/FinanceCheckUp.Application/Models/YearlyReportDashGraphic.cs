namespace FinanceCheckUp.Application.Models
{
    public class YearlyReportDashGraphic
    {
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public Decimal TotalGelir { get; set; }
    }
}
