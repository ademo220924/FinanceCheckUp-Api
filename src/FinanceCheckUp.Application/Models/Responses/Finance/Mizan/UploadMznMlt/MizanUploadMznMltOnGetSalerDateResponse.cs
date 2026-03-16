using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt
{
    public class MizanUploadMznMltOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadMznMltRequestInitialModel InitialModel { get; set; }
    }
}
