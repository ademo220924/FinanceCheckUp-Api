using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrm
{
    public class FinanceDashCrmOnGetCasinoResponse
    {
        public LoadResult Response  { get; set; }
        public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
    }
}
