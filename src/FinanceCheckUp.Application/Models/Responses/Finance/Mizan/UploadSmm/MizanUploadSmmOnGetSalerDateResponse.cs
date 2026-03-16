using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadSmm;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm
{
    public class MizanUploadSmmOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadSmmRequestInitialModel InitialModel { get; set; }
    }
}
