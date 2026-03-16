
namespace FinanceCheckUp.Application.Models;
public class DashBilancoViewMizan
{
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public string DebitCreditCode { get; set; }
    public double Amount { get; set; }
    public long CompanyID { get; set; }
    public int IsHidden { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }




    public bool getStatue()
    {
        int ncoun = 0;
        Boolean chk = true;
        if (Amount != 0) { ncoun++; }

        if (ncoun == 0)
        {
            chk = false;
        }

        return chk;
    }


}