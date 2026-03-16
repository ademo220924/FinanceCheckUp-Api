using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.dashbilancorvnmlt;
public class dashbilancorvnmltOnGetMarkupMarjinRequest
{
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
    public string myear { get; set; }
    public long compid { get; set; }
}