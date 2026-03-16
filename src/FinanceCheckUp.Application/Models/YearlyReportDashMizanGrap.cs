
namespace FinanceCheckUp.Application.Models;
public class YearlyReportDashMizanGrap
{
    public string Yeartx => Year.ToString();

    public int Year { get; set; }
    public long CompanyID { get; set; }
    public float Amount { get; set; }

}