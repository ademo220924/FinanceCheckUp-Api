using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn
{
    public class MizanUploadMznOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMznRequestInitialModel InitialModel { get; set; }
    }
}
