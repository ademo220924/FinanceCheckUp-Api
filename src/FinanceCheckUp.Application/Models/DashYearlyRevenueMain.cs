namespace FinanceCheckUp.Application.Models;

public class DashYearlyRevenueMain
{
    public string Description { get; set; }
    public DateTime Month { get; set; }
    public double Value { get; set; }
    public int SortVal { get; set; }
    public int TypeID { get; set; }
    public string GroupName { get; set; }
    public int CountrZone { get; set; }
}
