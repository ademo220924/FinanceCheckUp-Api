
namespace FinanceCheckUp.Application.Models;
public class DashYearlyResultMizan
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int TypeID { get; set; }
    public int Year { get; set; }
    public string Yeartx => Year.ToString();
}