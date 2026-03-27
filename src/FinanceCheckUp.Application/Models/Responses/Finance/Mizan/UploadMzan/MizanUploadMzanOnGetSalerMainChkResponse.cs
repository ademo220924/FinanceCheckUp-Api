using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan
{
    public class MizanUploadMzanOnGetSalerMainChkResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMzanRequestInitialModel InitialModel { get; set; }
    }
}
