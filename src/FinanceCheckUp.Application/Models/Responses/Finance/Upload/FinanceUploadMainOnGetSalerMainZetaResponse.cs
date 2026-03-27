using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Upload
{
    public class FinanceUploadMainOnGetSalerMainZetaResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
