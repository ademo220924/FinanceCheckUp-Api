using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
public class AktarmaDashBilancoOnGetMarkupMarjinResponse
{
    public JsonResult Response { get; set; }
    public AktarmaDashBilancoInitialModel InitialModel { get; set; }
}