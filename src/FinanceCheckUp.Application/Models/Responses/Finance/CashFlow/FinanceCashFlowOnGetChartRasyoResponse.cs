using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.CashFlow
{
    public class FinanceCashFlowOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceCashFlowRequestInitialModel InitialModel { get; set; }
    }
}
