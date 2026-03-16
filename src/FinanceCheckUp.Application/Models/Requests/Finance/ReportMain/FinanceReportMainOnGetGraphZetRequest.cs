using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.ReportMain
{
    public class FinanceReportMainOnGetGraphZetRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public int myear { get; set; }
        public long compid { get; set; }
    }
}
