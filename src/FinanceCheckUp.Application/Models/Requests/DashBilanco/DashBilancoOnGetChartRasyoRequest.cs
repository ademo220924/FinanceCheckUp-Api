using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.DashBilanco;
public class DashBilancoOnGetChartRasyoRequest
{
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
    public DashBilancoRequest InitialModel { get; set; }
}