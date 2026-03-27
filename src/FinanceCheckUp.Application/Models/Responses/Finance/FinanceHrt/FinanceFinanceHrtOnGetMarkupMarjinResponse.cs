using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrt;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt
{
    public class FinanceFinanceHrtOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public FinanceFinanceHrtRequestInitialModel InitialModel { get; set; }
    }
}
