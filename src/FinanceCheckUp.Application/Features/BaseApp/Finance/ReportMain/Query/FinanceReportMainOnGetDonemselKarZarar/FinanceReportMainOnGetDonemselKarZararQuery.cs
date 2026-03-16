using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetDonemselKarZarar;
public class FinanceReportMainOnGetDonemselKarZararQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainOnGetDonemselKarZararResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainOnGetDonemselKarZararRequest Request { get; set; }
}
