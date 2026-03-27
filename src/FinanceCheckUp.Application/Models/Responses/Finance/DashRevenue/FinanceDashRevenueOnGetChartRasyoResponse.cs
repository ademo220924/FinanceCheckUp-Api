using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenue;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue
{
    public class FinanceDashRevenueOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashRevenueRequestInitialModel InitialModel { get; set; }
    }
}
