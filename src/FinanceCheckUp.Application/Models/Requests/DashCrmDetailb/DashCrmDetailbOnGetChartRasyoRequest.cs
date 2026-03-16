
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCrmDetailb;
public class DashCrmDetailbOnGetChartRasyoRequest
{
    public DashCrmDetailbRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}