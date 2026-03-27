using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadSmm;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm
{
    public class MizanUploadSmmOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadSmmRequestInitialModel InitialModel { get; set; }
    }
}
