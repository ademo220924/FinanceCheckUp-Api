using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
public class dashbilancomltOnGetMarkupMarjinRequest
{

    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
    public string myear { get; set; }
    public long compid { get; set; }
}