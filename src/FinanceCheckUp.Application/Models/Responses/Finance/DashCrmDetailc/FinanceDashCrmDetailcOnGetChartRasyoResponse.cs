using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc
{
    public class FinanceDashCrmDetailcOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashCrmDetailcRequestInitialModel InitialModel { get; set; }
    }
}
