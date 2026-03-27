using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest
{
    public class FinanceReportMainTestOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public FinanceReportMainTestRequestInitialModel InitialModel { get; set; }
    }
}
