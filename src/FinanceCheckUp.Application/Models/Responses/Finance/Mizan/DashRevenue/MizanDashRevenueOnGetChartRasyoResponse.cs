using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue
{
    public class MizanDashRevenueOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashRevenueRequestInitialMopdel InitialModel { get; set; }
    }
}
