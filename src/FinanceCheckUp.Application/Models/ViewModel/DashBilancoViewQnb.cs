
namespace FinanceCheckUp.Application.Models.ViewModel;
public class DashBilancoViewQnb
{

    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    private double amount { get; set; }
    public double Amount
    {
        get { return amount; }
        set
        {
            if (value < 1 && value > 0)
            {
                value = 1;
            }
            amount = value;
        }
    }
    private double amount1 { get; set; }
    public double Amount1
    {
        get { return amount1; }
        set
        {
            if (value < 1 && value > 0)
            {
                value = 1;
            }
            amount1 = value;
        }
    }
    private double amount2 { get; set; }
    public double Amount2
    {
        get { return amount2; }
        set
        {
            if (value < 1 && value > 0)
            {
                value = 1;
            }
            amount2 = value;
        }
    }
    private double amount3 { get; set; }
    public double Amount3
    {
        get { return amount3; }
        set
        {
            if (value < 1 && value > 0)
            {
                value = 1;
            }
            amount3 = value;
        }
    }
    public long CompanyID { get; set; }
    public int IsHidden { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }
    public byte MainTypeID { get; set; }
    public double percentageChk { get; set; }
    public double percentageChka { get; set; }
    public double percentageChkb { get; set; }
    public double percentageChkc { get; set; }
}