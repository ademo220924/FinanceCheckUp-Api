
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashRevenue;
public class DashRevenueOnGetChartRasyoRequest
{
    public DashRevenueRequest InitialModel { get; internal set; }
    public DataSourceLoadOptions Options { get; set; }
}