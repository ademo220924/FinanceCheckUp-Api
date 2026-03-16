
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCpmNew;
public class DashCpmNewOnGetChartLikidRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public DashCpmNewRequest InitialModel { get; internal set; }
}