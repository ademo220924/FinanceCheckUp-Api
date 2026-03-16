using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco
{
    public class MizanAktarmaDashBilancoOnGetDonukResultRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public long compid { get; set; }
        public int nyear { get; set; }
    }
}
