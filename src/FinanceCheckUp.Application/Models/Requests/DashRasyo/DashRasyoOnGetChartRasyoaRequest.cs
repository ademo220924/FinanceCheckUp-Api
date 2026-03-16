
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashRasyo;
public class DashRasyoOnGetChartRasyoaRequest
{
    public DashRasyoRequest InitialModel { get; set; }
    public DataSourceLoadOptions Options { get; set; }
}