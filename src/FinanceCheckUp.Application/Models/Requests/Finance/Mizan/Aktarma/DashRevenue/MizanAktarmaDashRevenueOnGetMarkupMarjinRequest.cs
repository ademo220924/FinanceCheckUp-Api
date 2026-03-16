using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashRevenue
{
    public class MizanAktarmaDashRevenueOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public long compid { get; set; }
    }
}