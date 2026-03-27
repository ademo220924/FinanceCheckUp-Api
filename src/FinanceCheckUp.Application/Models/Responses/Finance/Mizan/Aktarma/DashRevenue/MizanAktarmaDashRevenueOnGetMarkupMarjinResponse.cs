using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashRevenue;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashRevenue
{
    public class MizanAktarmaDashRevenueOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanAktarmaDashRevenueRequestInitialModel InitialModel { get; set; }
    }
}
