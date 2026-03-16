using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView
{
    public class MizanFinanceHrtViewOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public int myear { get; set; }
        public long compid { get; set; }
    }
}
