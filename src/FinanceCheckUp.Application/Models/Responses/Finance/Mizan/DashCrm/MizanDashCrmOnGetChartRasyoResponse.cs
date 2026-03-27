using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm
{
    public class MizanDashCrmOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashCrmRequestInitialModel InitialModel { get; set; }
    }
}
