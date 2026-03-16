

namespace FinanceCheckUp.Application.Models.ViewModel;
public class DashAktarma
{
    public long ID { get; set; }
    public long CompanyID { get; set; }
    public int YEAR { get; set; }
    public long Value { get; set; }
    public string Message { get; set; }
    public bool ISInclude { get; set; }
    public DateTime CreatedDate { get; set; }
    public int TypeID { get; set; }
    public int? CheckValue { get; set; }
    public string AccountNo { get; set; }
    public string AccountName { get; set; }
    public string AccountNoII { get; set; }
    public string AccountNameII { get; set; }
}
