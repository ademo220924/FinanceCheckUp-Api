using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpBalance
{
    public class FinanceUpBalanceOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpBalanceRequestInitialModel InitialModel { get; set; }
    }
}
