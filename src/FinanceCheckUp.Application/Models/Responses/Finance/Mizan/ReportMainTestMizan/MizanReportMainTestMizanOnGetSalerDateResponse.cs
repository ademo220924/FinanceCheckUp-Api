using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan
{
    public class MizanReportMainTestMizanOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanReportMainTestMizanRequestInitialModel InitialModel { get; set; }
    }
}
