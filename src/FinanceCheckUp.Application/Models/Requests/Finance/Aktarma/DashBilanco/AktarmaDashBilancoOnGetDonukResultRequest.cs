using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
public class AktarmaDashBilancoOnGetDonukResultRequest
{
    public DataSourceLoadOptions options { get; set; }
    public long compid { get; set; }
    public int nyear { get; set; }
}
