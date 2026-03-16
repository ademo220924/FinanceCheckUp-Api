using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
public class AktarmaDashbilancomainOnGetMarkupMarjinResponse
{
    public AktarmaDashbilancomainInitialModel InitialModel { get; set; }
    public JsonResult Result { get; set; }
}
