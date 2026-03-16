using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerDate;
public class MizanReportMainTestMizanOldOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportMainTestMizanOldOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanReportMainTestMizanOldOnGetSalerDateRequest Request { get; set; }
    public MizanReportMainTestMizanOldRequestInitialModel InitialModel { get; set; }
}
