using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan
{
    public class MizanUploadMizanOnGetSalerMainChkResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadMizanRequestInitialModel InitialModel { get; set; }
    }
}
