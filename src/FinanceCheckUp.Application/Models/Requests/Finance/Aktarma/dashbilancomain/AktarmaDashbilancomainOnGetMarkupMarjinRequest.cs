using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
public class AktarmaDashbilancomainOnGetMarkupMarjinRequest
{
    public long compid { get; set; }
    public DataSourceLoadOptions options { get; set; }
}