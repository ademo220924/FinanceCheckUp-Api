using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital
{
    public class MizanDashWorkingCapitalOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashWorkingCapitalRequestInitialModel InitialModel { get; set; }
    }
}
