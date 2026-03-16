
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashRasyo;
public class DashRasyoOnGetChartRasyoRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public DashRasyoRequest InitialModel { get; set; }
}