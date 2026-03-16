using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtNeo;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo
{
    public class FinanceFinanceHrtNeoOnGetMarkupMarjinBResponse
    {
        public JsonResult Response { get; set; }
        public FinanceFinanceHrtNeoRequestInitialModel InitialModel { get; set; }
    }
}
