using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain
{
    public class MizanUploadMainOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
