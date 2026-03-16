using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo
{
    public class MizanFinanceHrtNeoOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanFinanceHrtNeoRequestInitialModel InitialModel { get; set; }
    }
}
