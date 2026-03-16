
namespace FinanceCheckUp.Application.Models;
public class DashBoard
{
    public int Pass { get; set; }
    public int Fail { get; set; }
    public int total => Pass + Fail;
    public long CompanyID { get; set; }
    public DateTime Datum { get; set; }
    public string datetext { get; set; }
}