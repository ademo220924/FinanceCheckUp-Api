using DevExtreme.AspNet.Data.ResponseModel;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew
{
    public class MizanUpBalanceNewOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUpBalanceNewRequestInitialModel InitialModel { get; set; }
    }
}
