using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue
{
    public class AktarmaDashRevenueOnGetMarkupMarjinResponse
    {
        public AktarmaDashRevenueInitialModel InitialModel { get; set; }
        public LoadResult Response { get; set; }
    }
}
