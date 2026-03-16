using FinanceCheckUp.Application.ExtensionHelpers;


namespace FinanceCheckUp.Application.Models;
public class BeyannameChk
{
    public BeyannameChk()
    { }
    public long ID { get; set; }
    public string AccountMainID { get; set; }
    public string AccountMainDescription => BeyannameChkHelper.RemoveEmpty(this.AccountMainDescriptionChk, this.IsGecici);
    public string AccountMainDescriptionChk { get; set; }
    public double Amount => BeyannameChkHelper.RemoveNonNumeric2(this.AccountMainDescriptionChk);
    public double AmountBefore => BeyannameChkHelper.RemoveNonNumeric1(this.AccountMainDescriptionChk, this.IsGecici);
    public string MainID { get; set; }
    public string SubID { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public DateTime CreatedDate { get; set; }
    public byte IsRevenue { get; set; }
    public byte IsGecici { get; set; }


}