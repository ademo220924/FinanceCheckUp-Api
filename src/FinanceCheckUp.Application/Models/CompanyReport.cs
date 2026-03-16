namespace FinanceCheckUp.Application.Models;
public class CompanyReport
{
    public int ID { get; set; }
    public long UserID { get; set; }
    public long CompanyID { get; set; }
    public DateTime CreatedDate { get; set; }
    public byte FileTypeID { get; set; }
    public byte ReportTypeID { get; set; }
    public string ReportName { get; set; }
    public int MainMonth { get; set; }
    public int MainYear { get; set; }
    public int MainCount { get; set; }
}
