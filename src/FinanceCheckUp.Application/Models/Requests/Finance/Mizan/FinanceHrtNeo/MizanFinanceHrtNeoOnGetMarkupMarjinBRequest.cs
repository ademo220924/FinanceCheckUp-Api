using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo
{
    public class MizanFinanceHrtNeoOnGetMarkupMarjinBRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
    }
}
