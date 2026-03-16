namespace FinanceCheckUp.Application.Models;
public class ERRLOG
{
    public int ID { get; set; }
    public string ERLOG { get; set; }
    public long CsvID { get; set; }
    public long CompanyID { get; set; }
    public DateTime CreatedDate { get; set; }
}