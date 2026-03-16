using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn
{
    public class MizanUploadMznOnGetSalerMainZetaResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadMznRequestInitialModel InitialModel { get; set; }
    }
}
