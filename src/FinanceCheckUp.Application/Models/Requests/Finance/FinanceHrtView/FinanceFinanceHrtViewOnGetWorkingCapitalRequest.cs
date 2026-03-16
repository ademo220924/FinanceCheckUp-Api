using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView
{
    public class FinanceFinanceHrtViewOnGetWorkingCapitalRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public int myear {  get; set; }
        public long compid { get; set; }
    }
}
