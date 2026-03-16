using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.CashFlow
{
    public class FinanceCashFlowOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public string myear {  get; set; }
        public long compid { get; set; }
    }
}
