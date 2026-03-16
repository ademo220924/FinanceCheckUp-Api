namespace FinanceCheckUp.Application.Models
{
    public class YearlyReportDash
    {
        public string Description { get; set; }
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public long TGelir { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public long TGider { get; set; }
        public long TotalGelir { get; set; }
        public float Amount { get; set; }
        public int TypeZone { get; set; }
        public int Year { get; set; }
        public string AmountTx => Amount.ToString("n0");
        public string YearTx => Year.ToString();
    }
}
