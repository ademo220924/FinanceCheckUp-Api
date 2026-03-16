using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo
{
    public class MizanDashRasyoOnGetDashRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashRasyoRequestInitialModel InitialModel { get; set; }
    }
}
