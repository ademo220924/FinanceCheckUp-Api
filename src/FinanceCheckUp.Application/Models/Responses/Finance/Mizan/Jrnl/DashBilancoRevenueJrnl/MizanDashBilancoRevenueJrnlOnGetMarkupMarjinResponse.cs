using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl
{
    public class MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoRevenueJrnlRequestInitialModel InitialModel { get; set; }
    }
}
