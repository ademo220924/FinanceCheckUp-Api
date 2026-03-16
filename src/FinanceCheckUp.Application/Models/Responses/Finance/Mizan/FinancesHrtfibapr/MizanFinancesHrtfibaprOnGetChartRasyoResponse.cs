using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr
{
    public class MizanFinancesHrtfibaprOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanFinancesHrtfibaprRequestInitialModel InitialModel { get; set; }
    }
}
