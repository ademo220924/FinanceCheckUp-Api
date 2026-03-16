using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCrmDetaila;

public class DashCrmDetailaOnGetChartRasyoRequest
{
    public DashCrmDetailaRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}
