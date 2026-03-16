using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenueMain;

public class AktarmaDashRevenueMainOnGetMarkupMarjinRequest
{
    public DataSourceLoadOptions options { get; set; }
    public long compid { get; set; }
}
