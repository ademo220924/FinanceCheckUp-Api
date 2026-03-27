using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl
{
    public class FinanceDashBilancoJrnlOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
    }
}
