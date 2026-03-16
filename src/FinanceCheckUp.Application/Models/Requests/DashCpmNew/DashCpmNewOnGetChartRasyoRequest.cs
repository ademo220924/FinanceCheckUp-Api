
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCpmNew;
public class DashCpmNewOnGetChartRasyoRequest
{
    public DashCpmNewRequest InitialModel { get; set; }
    public DataSourceLoadOptions Options { get; set; }
}