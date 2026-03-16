
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashRasyo;
public class DashRasyoOnGetChartMaliRequest
{
    public DashRasyoRequest InitialMode { get; set; }
    public DataSourceLoadOptions Options { get; set; }
}