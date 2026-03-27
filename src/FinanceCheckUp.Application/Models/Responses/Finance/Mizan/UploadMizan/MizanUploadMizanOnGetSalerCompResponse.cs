using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan
{
    public class MizanUploadMizanOnGetSalerCompResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMizanRequestInitialModel InitialModel { get; set; }
    }
}
