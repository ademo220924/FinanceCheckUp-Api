
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCrm;
public class DashCrmOnGetChartRasyobRequest
{
    public DashCrmRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}