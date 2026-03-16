using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashCompare
{
    public class MizanAktarmaDashCompareOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanAktarmaDashCompareRequestInitialModel InitialModel { get; set; }
    }
}
