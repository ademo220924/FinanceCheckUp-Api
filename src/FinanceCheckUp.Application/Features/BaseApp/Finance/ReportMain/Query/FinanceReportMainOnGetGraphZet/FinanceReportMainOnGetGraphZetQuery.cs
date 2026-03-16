using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetGraphZet;
public class FinanceReportMainOnGetGraphZetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainOnGetGraphZetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainOnGetGraphZetRequest Request { get; set; }
}
