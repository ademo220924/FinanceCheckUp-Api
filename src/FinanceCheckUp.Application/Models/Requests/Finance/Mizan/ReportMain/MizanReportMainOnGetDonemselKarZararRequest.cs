using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMain
{
    public class MizanReportMainOnGetDonemselKarZararRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
    }
}
