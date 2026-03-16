using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn
{
    public class FinanceUpPageAktarmaMznOnGetSalerDateMainResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpPageAktarmaMznRequestInitialModel InitialModel { get; set; }
    }
}
