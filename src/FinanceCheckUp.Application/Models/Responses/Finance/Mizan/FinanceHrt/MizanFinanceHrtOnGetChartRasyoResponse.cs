using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt
{
    public class MizanFinanceHrtOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanFinanceHrtRequestInitialModel InitialModel { get; set; }
    }
}
