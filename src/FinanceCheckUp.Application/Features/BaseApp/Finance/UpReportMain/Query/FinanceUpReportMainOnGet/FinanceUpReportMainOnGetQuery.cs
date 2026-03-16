using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGet;
public class FinanceUpReportMainOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpReportMainOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpReportMainOnGetRequest Request { get; set; }
}
