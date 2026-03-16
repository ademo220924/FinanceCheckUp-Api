using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare
{
    public class MizanAktarmaDashCompareOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
        public int nmonth { get; set; }
        public int nyear { get; set; }
    }
}