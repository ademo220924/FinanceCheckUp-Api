using DevExtreme.AspNet.Mvc;
namespace FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView
{
    public class FinanceFinanceHrtViewOnGetRevenueRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
        public int myear { get; set; }
    }
}
