
namespace FinanceCheckUp.Application.Models;
public class YearlyReportDashMizan
{

    public string Yeartx => Year.ToString();

    public int Year { get; set; }
    public long CompanyID { get; set; }
    public long Amount { get; set; }

}