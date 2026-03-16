
namespace FinanceCheckUp.Application.Models.Requests.upcheck;
public class upcheckOnGetCheckRepPdfRequest
{
    public long companyID { get; set; }
    public int nyear { get; set; }
    public int nmonth { get; set; }
}