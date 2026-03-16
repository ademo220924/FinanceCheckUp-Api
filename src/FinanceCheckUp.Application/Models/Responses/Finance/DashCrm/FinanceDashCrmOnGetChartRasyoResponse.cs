using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrm
{
    public class FinanceDashCrmOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
    }
}
