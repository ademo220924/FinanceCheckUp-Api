using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr
{
    public class MizanFinancesHrtfibaprOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanFinancesHrtfibaprRequestInitialModel InitialModel { get; set; }
    }
}
