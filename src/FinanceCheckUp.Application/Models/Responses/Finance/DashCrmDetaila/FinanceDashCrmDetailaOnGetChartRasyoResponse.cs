using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetaila;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetaila
{
    public class FinanceDashCrmDetailaOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashCrmDetailaRequestInitialModel InitialModel { get; set; }
    }
}
