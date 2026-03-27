using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetail;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetail
{
    public class FinanceDashCrmDetailOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashCrmDetailRequestInitialModel Request { get; set; }
    }
}
