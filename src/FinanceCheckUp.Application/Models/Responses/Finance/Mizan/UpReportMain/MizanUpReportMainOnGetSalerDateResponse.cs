using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpReportMain;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain
{
    public class MizanUpReportMainOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUpReportMainRequestInitialModel InitialModel { get; set; }
    }
}
