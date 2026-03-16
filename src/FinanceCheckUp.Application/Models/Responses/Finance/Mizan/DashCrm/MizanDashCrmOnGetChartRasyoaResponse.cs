using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;

public class MizanDashCrmOnGetChartRasyoaResponse
{
    public JsonResult Response { get; set; }
    public MizanDashCrmRequestInitialModel InitialModel { get; set; }
    
}
