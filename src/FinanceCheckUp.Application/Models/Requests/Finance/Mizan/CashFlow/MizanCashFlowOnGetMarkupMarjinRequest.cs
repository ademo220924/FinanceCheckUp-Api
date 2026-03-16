using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow
{
    public class MizanCashFlowOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public string myear {  get; set; }
        public long compid { get; set; }
    }
}
