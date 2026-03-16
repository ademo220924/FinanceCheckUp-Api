
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetailb;

namespace FinanceCheckUp.Application.Models.Requests.DashCrmDetailc;
public class DashCrmDetailcOnGetChartRasyoRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public DashCrmDetailbRequest InitialModel { get; internal set; }
}