using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrt;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt
{
    public class FinanceFinanceHrtOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public FinanceFinanceHrtRequestInitialModel InitialModel { get; set; }
    }
}
