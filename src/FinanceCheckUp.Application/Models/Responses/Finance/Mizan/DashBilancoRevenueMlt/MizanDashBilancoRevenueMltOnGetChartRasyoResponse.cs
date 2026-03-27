using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueMlt;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt
{
    public class MizanDashBilancoRevenueMltOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoRevenueMltRequestInitialModel InitialModel { get; set; }
    }
}
