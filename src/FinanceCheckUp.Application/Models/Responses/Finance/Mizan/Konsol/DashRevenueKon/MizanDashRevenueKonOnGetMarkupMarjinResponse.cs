using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon
{
    public class MizanDashRevenueKonOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashRevenueKonRequestInitialModel InitialModel { get; set; }
    }
}
