using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo
{
    public class MizanFinanceHrtNeoOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanFinanceHrtNeoRequestInitialModel InitialModel { get; set; }
    }
}
