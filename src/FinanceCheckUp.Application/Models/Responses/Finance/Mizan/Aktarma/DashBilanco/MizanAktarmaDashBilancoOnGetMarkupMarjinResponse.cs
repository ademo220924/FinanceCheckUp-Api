using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco
{
    public class MizanAktarmaDashBilancoOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanAktarmaDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
