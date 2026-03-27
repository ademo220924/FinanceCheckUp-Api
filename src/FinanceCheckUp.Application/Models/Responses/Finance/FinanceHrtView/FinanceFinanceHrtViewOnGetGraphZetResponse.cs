using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView
{
    public class FinanceFinanceHrtViewOnGetGraphZetResponse
    {
        public LoadResult Response { get; set; }
        public FinanceFinanceHrtViewRequestInitialModel InitialModel { get; set; }
    }
}
