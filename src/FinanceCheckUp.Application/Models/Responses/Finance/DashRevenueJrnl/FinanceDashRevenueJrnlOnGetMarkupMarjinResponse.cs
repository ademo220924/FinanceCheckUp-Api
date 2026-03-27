using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenueJrnl;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRevenueJrnl
{
    public class FinanceDashRevenueJrnlOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashRevenueJrnlRequestInitialModel InitialModel { get; set; }
    }
}
