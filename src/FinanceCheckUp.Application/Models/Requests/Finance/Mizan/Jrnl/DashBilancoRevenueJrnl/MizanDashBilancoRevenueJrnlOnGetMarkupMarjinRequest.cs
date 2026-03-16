using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl
{
    public class MizanDashBilancoRevenueJrnlOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
    }
}
