using FinanceCheckUp.Application.Models.Requests.Finance.DashBilanco;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco
{
    public class FinanceDashBilancoOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
