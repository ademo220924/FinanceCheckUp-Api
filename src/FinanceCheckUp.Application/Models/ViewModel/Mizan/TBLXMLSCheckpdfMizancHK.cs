namespace FinanceCheckUp.Application.Models.ViewModel.Mizan;

public class TBLXMLSCheckpdfMizancHK
{
    public int pageID { get; set; }
    public long ID { get; set; }
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public double Amount1 { get; set; }
    public double Amount2 { get; set; }
    public double Amount3 { get; set; }
    public double Amount4 { get; set; }
    public string lineMainDescription { get; set; }
    public TBLXMLSCheckpdfMizancHK()
    {
        AccountMainID = "";
        AccountMainDescription = "";
        lineMainDescription = "";
    }
}