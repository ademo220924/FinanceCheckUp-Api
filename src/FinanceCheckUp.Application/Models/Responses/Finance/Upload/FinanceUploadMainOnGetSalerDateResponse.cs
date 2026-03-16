using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Upload
{
    public class FinanceUploadMainOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
