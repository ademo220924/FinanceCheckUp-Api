using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
public class AktarmaDashRevenueOnGetMarkupMarjinRequest
{
    public DataSourceLoadOptions options { get; set; }
    public long compid { get; set; }
}
