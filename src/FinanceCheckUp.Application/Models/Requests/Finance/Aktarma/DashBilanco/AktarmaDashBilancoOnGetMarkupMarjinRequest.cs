using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
public class AktarmaDashBilancoOnGetMarkupMarjinRequest
{
    public long compid { get; set; }
    public DataSourceLoadOptions options { get; set; }

}
