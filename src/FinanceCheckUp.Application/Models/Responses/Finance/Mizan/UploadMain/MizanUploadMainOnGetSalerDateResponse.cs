using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain
{
    public class MizanUploadMainOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
