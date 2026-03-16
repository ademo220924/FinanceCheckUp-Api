using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilanco;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco
{
    public class MizanDashBilancoOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
