using FinanceCheckUp.Application.Models.Requests.Upload;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.Upload;
public class UploadOnGetSalerMainZetaResponse
{
    public LoadResult Result { get; set; }
    public UploadRequest InitialModel { get; internal set; }
}