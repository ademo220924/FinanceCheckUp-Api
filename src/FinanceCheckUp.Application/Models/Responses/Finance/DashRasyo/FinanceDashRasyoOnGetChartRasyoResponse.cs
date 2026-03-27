using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo
{
    public class FinanceDashRasyoOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
    }
}
