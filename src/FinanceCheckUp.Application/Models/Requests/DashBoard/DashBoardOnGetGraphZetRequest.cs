using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.DashBoard;
public class DashBoardOnGetGraphZetRequest
{
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
    public int myear { get; set; }
    public long compid { get; set; }
}