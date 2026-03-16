
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashCrmDetail;
public class DashCrmDetailOnGetChartRasyoRequest
{
    public DashCrmDetailRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}