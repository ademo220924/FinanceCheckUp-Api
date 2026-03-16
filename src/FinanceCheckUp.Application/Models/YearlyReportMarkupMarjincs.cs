namespace FinanceCheckUp.Application.Models;


public class YearlyReportMarkupMarjin
{
    public int MainYear { get; set; }
    public int MainMonth { get; set; }
    public decimal TGelir { get; set; }
    public string DocumentMonth { get; set; }
    public string DocumentMonthTr { get; set; }
    public decimal TGider { get; set; }
    public decimal TotalGelir { get; set; }
    public decimal TotalGelirTx { get; set; }
}