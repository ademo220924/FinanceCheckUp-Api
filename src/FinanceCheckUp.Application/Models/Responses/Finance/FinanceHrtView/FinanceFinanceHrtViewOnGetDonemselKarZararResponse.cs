using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView
{
    public class FinanceFinanceHrtViewOnGetDonemselKarZararResponse
    {
        public JsonResult Response { get; set; }
        public FinanceFinanceHrtViewRequestInitialModel InitialModel { get; set; }
    }
}
