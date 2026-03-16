using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetRevenue;
public class FinanceReportMainOnGetRevenueQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainOnGetRevenueResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainOnGetRevenueRequest Request { get; set; }
}
