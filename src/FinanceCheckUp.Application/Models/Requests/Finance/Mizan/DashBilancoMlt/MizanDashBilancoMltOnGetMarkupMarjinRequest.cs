using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoMlt
{
    public class MizanDashBilancoMltOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public string myear {  get; set; }
        public long compid { get; set; }
    }
}
