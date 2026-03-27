using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt
{
    public class MizanUploadMznMltOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMznMltRequestInitialModel InitialModel { get; set; }
    }
}
