
namespace FinanceCheckUp.Application.Models.Requests.upaccount;
public class upaccountOnGetCheckRepPdfRequest
{
    public long companyID { get; set; }
    public int nyear { get; set; }
    public int nmonth { get; set; }
}