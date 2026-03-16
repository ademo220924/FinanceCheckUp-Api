using FinanceCheckUp.Application.Models.Requests.CashFlow;


namespace FinanceCheckUp.Application.Models.Responses.CashFlow;
public class OnGetResponseModel
{
    public IEnumerable<YearResult> YearResults { get; set; }
    public CashFlowRequestModel CashFlowRequestInit { get; internal set; }
}