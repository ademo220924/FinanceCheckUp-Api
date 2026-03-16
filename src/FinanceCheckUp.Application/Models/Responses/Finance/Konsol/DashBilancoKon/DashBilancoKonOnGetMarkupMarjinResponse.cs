using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashBilancoKon;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon
{
    public class DashBilancoKonOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public DashBilancoKonInitialModel InitialModel { get; set; }
    }
}
