using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGet;
public class MizanReportMainTestMizanOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportMainTestMizanOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanReportMainTestMizanOnGetRequest Request { get; set; }
}
