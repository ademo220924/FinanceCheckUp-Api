using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerComp;
public class FinanceReportMainTestOldOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOldOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOldOnGetSalerCompRequest Request { get; set; }
}
