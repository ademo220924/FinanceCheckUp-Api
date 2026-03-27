using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoJrnl;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoJrnl
{
    public class MizanDashBilancoJrnlOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
    }
}
