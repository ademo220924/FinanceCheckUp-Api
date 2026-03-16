
namespace FinanceCheckUp.Application.Models;
public class DashDonukView
{
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public string AccountSubID { get; set; }
    public string AccountSubDescription { get; set; }
    public string DebitCreditCode { get; set; }
    public double Acilis { get; set; }
    public double March { get; set; }
    public double April { get; set; }
    public double September { get; set; }
    public double December { get; set; }

    public long CompanyID { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int OrderID { get; set; }

}