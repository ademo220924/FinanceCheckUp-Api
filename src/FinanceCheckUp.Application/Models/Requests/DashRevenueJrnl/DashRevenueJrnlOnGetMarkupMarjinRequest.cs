
using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;
public class DashRevenueJrnlOnGetMarkupMarjinRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public string Myear { get; set; }
    public long Compid { get; set; }
}