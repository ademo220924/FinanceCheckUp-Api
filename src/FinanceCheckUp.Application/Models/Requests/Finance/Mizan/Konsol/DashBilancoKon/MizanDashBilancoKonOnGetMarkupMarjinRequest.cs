using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon
{
    public class MizanDashBilancoKonOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public long compid { get; set; }
    }
}
