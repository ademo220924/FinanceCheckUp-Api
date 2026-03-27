using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.ReportMain
{
    public class FinanceReportMainOnGetWorkingCapitalResponse
    {
        public LoadResult Response { get; set; }
        public FinanceReportMainRequestInitialModel InitialModel { get; set; }
    }
}
