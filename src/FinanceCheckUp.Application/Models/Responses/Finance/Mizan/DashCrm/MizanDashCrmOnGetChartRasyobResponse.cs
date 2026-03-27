using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;

public class MizanDashCrmOnGetChartRasyobResponse
{
    public LoadResult Response { get; set; }
    public MizanDashCrmRequestInitialModel InitialModel { get; set; }
}
