
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCpmNew;
public class DashCpmNewOnGetChartMaliRequest
{
    public DashCpmNewRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}