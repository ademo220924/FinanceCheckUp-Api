using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance
{
    public class MizanUpBalanceOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUpBalanceRequestInitialModel InitialModel { get; set; }
    }
}
