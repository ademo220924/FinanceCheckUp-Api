using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.ReportMain
{
    public class FinanceReportMainOnGetDonemselKarZararRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public int myear { get; set; }
        public long compid { get; set; }
    }
}
