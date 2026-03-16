using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn
{
    public class FinanceUpPageAktarmaMznOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpPageAktarmaMznRequestInitialModel InitialModel { get; set; }
    }
}
