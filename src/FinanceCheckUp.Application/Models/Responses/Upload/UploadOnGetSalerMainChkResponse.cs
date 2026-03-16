using FinanceCheckUp.Application.Models.Requests.Upload;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.Upload;
public class UploadOnGetSalerMainChkResponse
{
    public JsonResult Result { get; set; }
    public UploadRequest InitialModel { get; set; }
}