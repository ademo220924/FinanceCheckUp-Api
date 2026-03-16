namespace FinanceCheckUp.Application.Models.ViewModel.Mizan;

public class TBLXMLSCheckpdfMizan
{
    public int PageID { get; set; }
    public long ID { get; set; }
    public string AccountMainZet => (AccountMainID + AccountMainDescription).Replace(" ", "");
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public double Amount1 { get; set; }
    public double Amount2 { get; set; }
    public double Amount3 { get; set; }
    public double Amount4 { get; set; }
    public int Amount1Diff { get; set; }
    public int Amount2Diff { get; set; }
    public int Amount3Diff { get; set; }
    public int Amount4Diff { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public byte MainMonth { get; set; }
}