
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCrm;
public class DashCrmOnGetChartMaliRequest
{
    public DashCrmRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}