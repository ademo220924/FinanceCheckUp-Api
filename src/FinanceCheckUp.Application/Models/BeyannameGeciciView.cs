
namespace FinanceCheckUp.Application.Models;
public class BeyannameGeciciView
{
    public long ID { get; set; }
    public string AccountMainID { get; set; }
    public string AccountMainDescription;
    public string AccountMainDescriptionChk { get; set; }
    public double Amount;
    public double AmountBefore;
    public string MainID { get; set; }
    public string SubID { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public DateTime CreatedDate { get; set; }
    public byte IsRevenue { get; set; }
}