using FinanceCheckUp.Application.Models.Requests.Finance.DashBilanco;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco
{
    public class FinanceDashBilancoOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
